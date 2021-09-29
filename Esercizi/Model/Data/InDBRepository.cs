using Esercizi.Classes;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Esercizi.Model.Data
{
    public class InDBRepository : IRepository
    {
        
        #region Query
        #region QuerySelect
        const string CONNECTION_STRING = "Server = localhost; User=sa; Password=1Secure*Password; Database = scuola";
            const string SELECT_AULA = @"Select id, nome, capacita_massima,fisica,computerizzata, proiettore
                                        From dbo.aula
                                        where @id=id";
            const string SELECT_AZIENDA = @"Select id, nome, citta, indirizzo, cap, telefono, email, partita_iva
                                           From dbo.azienda
                                           where @id=id";
            const string SELECT_CATEGORIA = @"Select id, descrizione, tipo
                                            FROM dbo.categoria
                                            where @id=id";
            const string SELECT_FINANZIATORE = @"Select id, descrizione
                                                FROM dbo.finanziatore
                                                where @id=id";
            const string SELECT_LIVELLO = @"Select id, descrizione, tipo
                                            FROM dbo.livello
                                            where @id=id";
            const string SELECT_PROGETTO = @"Select id, descrizione, id_azienda
                                            FROM dbo.progetto
                                            where @id=id";
            const string SELECT_CORSO = @"Select id, titolo, descrizzione, ammontare_ore, costo_di_riferimento, id_livello, id_progetto, id_categoria
                                          FROM dbo.corso
                                          where @id=id";
            const string SELECT_ALL_CORSO = @"Select id, titolo, descrizzione, ammontare_ore, costo_di_riferimento, id_livello, id_progetto, id_categoria
                                            FROM dbo.corso";
            const string SELECT_ALL_EDITIONS = @"Select id, codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, id_presenza, id_aula, id_corso, id_finanziatore
                                                FROM dbo.edizioni";
        #endregion
        #region QueryInsert
        const string INSERT_AULA = @"INSERT INTO dbo.aula (nome, capacita_massima, fisica, computerizzata, proiettore)
                                            OUTPUT INSERTED.id  
                                            VALUES (@nome, @capacita_massima, @fisica, @computerizzata, @proiettore);";
        const string INSERT_AZIENDA = @"INSERT INTO dbo.azienda (nome, citta, indirizzo, cap, telefono, email, partita_iva)
                                            OUTPUT INSERTED.id  
                                            VALUES (@nome, @citta, @indirizzo, @cap, @telefono, @email, @partita_iva);";
        const string INSERT_CATEGORIA = @"INSERT INTO dbo.categoria (descrizione, argomento)
                                            OUTPUT INSERTED.id  
                                            VALUES (@descrizione, @argomento);";
        const string INSERT_FINANZIATORE = @"INSERT INTO dbo.finanziatore (descrizione)
                                                OUTPUT INSERTED.id  
                                                VALUES (@descrizione);";
        const string INSERT_LIVELLO = @"INSERT INTO dbo.livello (descrizione, tipo)
                                            OUTPUT INSERTED.id  
                                            VALUES (@descrizione, @tipo);";
        const string INSERT_CORSO = @"INSERT INTO dbo.corso (titolo, descrizzione, ammontare_ore, costo_di_riferimento, id_progetto, id_livello, id_categoria)
                                          OUTPUT INSERTED.id  
                                          VALUES (@titolo, @descrizzione, @ammontare_ore, @costo_di_riferimento, @id_progetto, @id_livello, @id_categoria);";
        const string INSERT_EDIZIONE = @"INSERT INTO dbo.edizioni (codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, in_presenza, id_aula, id_corso, id_finanziatore)
                                             OUTPUT INSERTED.id 
                                             VALUES (@codice_edizione, @data_inizio, @data_fine, @prezzo_finale, @numero_studenti_massimo, @in_presenza, @id_aula, @id_corso, @id_finanziatore);";
        #endregion
        #endregion
        #region Corsi
        public bool CourseExists(Corso c)
        {
            throw new NotImplementedException();
        }
        public Corso GetCourseById(long idCorso)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Corso cr = null;
                    SqlCommand cmd = new SqlCommand(SELECT_CORSO, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idCorso;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = (int)idCorso;
                            string titolo = reader.GetString("titolo");
                            string descrizione = reader.GetString("descrizzione");
                            int ammontare_ore = reader.GetInt32("ammontare_ore");
                            decimal costo_di_riferimento = reader.GetDecimal("costo_di_riferimento");
                            int id_livello = reader.GetInt32("id_livello");
                            int id_progetto = reader.GetInt32("id_progetto");
                            int id_categoria = reader.GetInt32("id_categoria");
                            cr = new Corso(id, titolo, ammontare_ore, (long)costo_di_riferimento, id_livello, id_progetto, id_categoria, descrizione);                           
                        }
                        return cr;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Corso SetCourse(Corso corso) 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_CORSO, conn);
                    //cmd.Parameters.AddWithValue("@id", corso.Id);
                    cmd.Parameters.AddWithValue("@titolo", corso.Titolo);
                    cmd.Parameters.AddWithValue("@descrizzione", corso.Descrizione);
                    cmd.Parameters.AddWithValue("@ammontare_ore", corso.AmmontareOre);
                    cmd.Parameters.AddWithValue("@costo_di_riferimento", corso.CostoDiRiferimento);
                    cmd.Parameters.AddWithValue("@id_livello", corso.IdLivello);
                    cmd.Parameters.AddWithValue("@id_progetto", corso.IdProgetto);
                    cmd.Parameters.AddWithValue("@id_categoria", corso.IdCategoria);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    int newId = (int)cmd.ExecuteScalar();
                    corso.Id = newId;
                    return corso;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public IEnumerable<Corso> GetCourses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(SELECT_ALL_CORSO, conn);
                    List<Corso> r = new List<Corso>();
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string titolo = reader.GetString("titolo");
                            string descrizione = reader.GetString("descrizzione");
                            int ammontare_ore = reader.GetInt32("ammontare_ore");
                            decimal costo_di_riferimento = reader.GetDecimal("costo_di_riferimento");
                            int id_livello = reader.GetInt32("id_livello");
                            int id_progetto = reader.GetInt32("id_progetto");
                            int id_categoria = reader.GetInt32("id_categoria");
                            Corso cr = new Corso(id, titolo, ammontare_ore, (long)costo_di_riferimento, id_livello, id_progetto, id_categoria, descrizione);
                            r.Add(cr);
                        }
                    }

                    return r;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion
        #region EdizioneCorsi
        public EdizioneCorso SetEdition(EdizioneCorso edizione)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                 
                    SqlCommand cmd = new SqlCommand(INSERT_EDIZIONE, conn);
                    //cmd.Parameters.AddWithValue("@id", edizione.Id);
                    cmd.Parameters.AddWithValue("@codice_edizione", edizione.CodiceEdizione);
                    cmd.Parameters.AddWithValue("@data_inizio", edizione.Start.AtMidnight().ToDateTimeUnspecified());
                    cmd.Parameters.AddWithValue("@data_fine", edizione.End.AtMidnight().ToDateTimeUnspecified());
                    cmd.Parameters.AddWithValue("@prezzo_finale", edizione.RealPrice);
                    cmd.Parameters.AddWithValue("@in_presenza", 1);
                    cmd.Parameters.AddWithValue("@numero_studenti_massimo", edizione.NumStudents);
                    cmd.Parameters.AddWithValue("@id_aula", edizione.IdAula);
                    cmd.Parameters.AddWithValue("@id_corso", edizione.IdCorso);
                    cmd.Parameters.AddWithValue("@id_finanziatore", edizione.IdFinanziatore);
                    conn.Open();
                    int newId = (int)cmd.ExecuteScalar();
                    edizione.Id = newId;
                    //cmd.ExecuteNonQuery();
                    
                }
                return edizione;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public EdizioneCorso GetEditionbyId(long id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {

                    SqlCommand cmd = new SqlCommand(SELECT_ALL_EDITIONS, conn);
                    conn.Open();
                    EdizioneCorso cr=null;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int intid = (int)id;
                            string codice_edizione = reader.GetString("codice_edizione");
                            LocalDate data_inizio = reader.GetLocalDate("data_inizio");
                            LocalDate data_fine = reader.GetLocalDate("data_fine");
                            decimal prezzo_finale = reader.GetDecimal("prezzo_finale");
                            int numero_studenti_massimo = reader.GetInt32("numero_studenti_massimo");
                            long id_presenza = reader.GetInt32("id_presenza");
                            long id_aula = reader.GetInt32("id_aula");
                            long id_corso = reader.GetInt32("id_corso");
                            long id_finanziatore = reader.GetInt32("id_finanziatore");
                            cr = new EdizioneCorso(codice_edizione, id_corso, data_inizio, data_fine, numero_studenti_massimo, prezzo_finale, id_aula, id_finanziatore);
                            return cr;
                        }
                        return cr;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId)
        {
          try
          {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {                     
                    SqlCommand cmd = new SqlCommand(SELECT_ALL_EDITIONS, conn);
                    List<EdizioneCorso> r = new List<EdizioneCorso>();
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string codice_edizione = reader.GetString("codice_edizione");
                            LocalDate data_inizio = reader.GetLocalDate("data_inizio");
                            LocalDate data_fine = reader.GetLocalDate("data_fine");

                            decimal prezzo_finale = reader.GetDecimal("prezzo_finale");
                            int numero_studenti_massimo = reader.GetInt32("numero_studenti_massimo");
                            long id_presenza = reader.GetInt32("id_presenza");
                            long id_aula = reader.GetInt32("id_aula");
                            //long id_presenza = reader.GetInt32("id_presenza", 1);

                            long id_corso = reader.GetInt32("id_corso");
                            long id_finanziatore = reader.GetInt32("id_finanziatore");
                            EdizioneCorso cr = new EdizioneCorso(codice_edizione, id_corso, data_inizio, data_fine, numero_studenti_massimo, prezzo_finale, id_aula, id_finanziatore);
                            r.Add(cr);
                        }
                    }
                    return r;
                }
            }
          catch (SqlException e)
          {
                Console.WriteLine(e);
                return null;
          }
        }
        public Report GenerateStatisticalReport(long idCorso)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Get
        public Aula GetAulabyId(long idAula)
        {
            try
            {
                using (SqlConnection conn= new SqlConnection(CONNECTION_STRING))
                {
                    Aula cl = null;
                    SqlCommand cmd = new SqlCommand(SELECT_AULA, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idAula;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nome = reader.GetString("nome");
                            long capacita_massima = reader.GetInt32("capacita_massima");
                            bool isFisica = reader.GetNBoolean("fisica");
                            bool? isComputerized = reader.GetBoolean("computerizzata");
                            bool? hasProjector = reader.GetBoolean("proiettore");
                            cl = new Aula(idAula, nome, capacita_massima, isFisica, isComputerized, hasProjector);
                        }
                    }
                    return cl;
                }
            }
            catch (SqlException e) 
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Azienda GetAziendabyId(long idAzienda)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Azienda az = null;
                    SqlCommand cmd = new SqlCommand(SELECT_AZIENDA, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idAzienda;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nome = reader.GetString("nome");
                            string citta = reader.GetString("nome");
                            string indirizzo = reader.GetString("indirizzo");
                            string cap = reader.GetString("cap");
                            string telefono = reader.GetString("telefono");
                            string email = reader.GetString("email");
                            string partita_iva = reader.GetString("partita_iva");
                            az = new Azienda((int)idAzienda, nome, citta, indirizzo, cap, telefono, email, partita_iva);
                        }
                        return az;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Categoria GetCategoriabyId(long idCategoria)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Categoria ct = null;
                    SqlCommand cmd = new SqlCommand(SELECT_CATEGORIA, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idCategoria;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descrizione = reader.GetString("descrizione");
                            string tipo = reader.GetString("tipo");
                            ct = new Categoria((int)idCategoria, descrizione, tipo);
                        }
                        return ct;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Finanziatore GetFinanziatorebyId(long idFinanziatore)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Finanziatore fz = null;
                    SqlCommand cmd = new SqlCommand(SELECT_FINANZIATORE, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idFinanziatore;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descrizione = reader.GetString("descrizione");
                            fz = new Finanziatore((int)idFinanziatore, descrizione);
                        }
                        return fz;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Livello GetLivellobyId(long idLivello)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Livello lv = null;
                    SqlCommand cmd = new SqlCommand(SELECT_LIVELLO, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idLivello;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descrizione = reader.GetString("descrizione");
                            lv = new Livello((int)idLivello, descrizione);
                        }
                        return lv;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Progetto GetProgettobyId(long idProgetto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Progetto lv = null;
                    SqlCommand cmd = new SqlCommand(SELECT_PROGETTO, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = idProgetto;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descrizione = reader.GetString("descrizione");
                            long idAzienda = reader.GetLong("id_azienda");                          
                            lv = new Progetto((int)idProgetto, descrizione, idAzienda);
                        }
                        return lv;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion
        #region Set
        public Aula SetAula(Aula aula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_AULA, conn);
                    cmd.Parameters.AddWithValue("@nome", aula.Name);
                    cmd.Parameters.AddWithValue("@capacita_massima", aula.MaxCapacity);
                    cmd.Parameters.AddWithValue("@fisica", aula.IsPhysical);
                    cmd.Parameters.AddWithValue("@computerizzata", aula.IsComputerized);
                    cmd.Parameters.AddWithValue("@proiettore", aula.HasProjector);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    long newId = (long)cmd.ExecuteScalar();
                    aula.Id = newId;                    
                }
                return aula;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: "+e.Message);
                return null;
            }
        }
        public Azienda SetAzienda(Azienda azienda)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_AZIENDA, conn);
                    cmd.Parameters.AddWithValue("@nome", azienda.Nome);
                    cmd.Parameters.AddWithValue("@citta", azienda.Citta);
                    cmd.Parameters.AddWithValue("@indirizzo", azienda.Indirizzo);
                    cmd.Parameters.AddWithValue("@cap", azienda.Cap);
                    cmd.Parameters.AddWithValue("@telefono", azienda.Telefono);
                    cmd.Parameters.AddWithValue("@email", azienda.Email);
                    cmd.Parameters.AddWithValue("@partita_iva", azienda.PartitaIva);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    long newId = (long)cmd.ExecuteScalar();
                    azienda.Id = (int)newId;                    
                }
                return azienda;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public Categoria SetCategoria(Categoria categoria)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_CATEGORIA, conn);
                    cmd.Parameters.AddWithValue("@descrizione", categoria.Descrizione);
                    cmd.Parameters.AddWithValue("@argomento", categoria.Argomento);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    long newId = (long)cmd.ExecuteScalar();
                    categoria.Id = (int)newId;                    
                }
                return categoria;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public Finanziatore SetFinanziatore(Finanziatore finanziatore)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_FINANZIATORE, conn);
                    cmd.Parameters.AddWithValue("@descrizione", finanziatore.Descrizione);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    long newId = (long)cmd.ExecuteScalar();
                    finanziatore.Id = newId;
                }
                return finanziatore;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public Livello SetLivello(Livello level)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_LIVELLO, conn);
                    cmd.Parameters.AddWithValue("@descrizione", level.Descrizione);
                    cmd.Parameters.AddWithValue("@argomento", level.Tipo);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    long newId = (long)cmd.ExecuteScalar();
                    level.Id = (int)newId;
                }
                return level;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        public Progetto SetProgetto(Progetto progetto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_LIVELLO, conn);
                    cmd.Parameters.AddWithValue("@descrizione", progetto.Descrizione);
                    cmd.Parameters.AddWithValue("@id_azienda", progetto.IdAzienda);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    long newId = (long)cmd.ExecuteScalar();
                    progetto.Id = (int)newId;
                }
                return progetto;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
        #endregion
    }
}
