using Esercizi.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Esercizi.Model.Data
{
    public class InDBRepository : IRepository
    {
        #region Query
            #region QueryAdd
            const string CONNECTION_STRING = @"Server = localhost;             
                                            User=sa;             
                                            Password=1Secure*Password;             
                                            Database = scuola";
            const string SELECT_AULA = @"Select id, nome, capacita_massima,fisica,computerizzata, proiettore
                                        From dbo.aula
                                        where @id=id";
            const string SELECT_AZIENDA = @"Select id, nome, citta, indirizzo, cap, telefono, email, partita_iva
                                           From dbo.azienda
                                           where @id=id";
            const string SELECT_CATEGORIA = @"Select id, descrizione, argomento
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
            const string SELECT_CORSO = @"Select id, titolo, descrizione, ammontare_ore, costo_di_riferimento, id_livello, id_progetto, id_categoria
                                          FROM dbo.corso
                                          where @id=id";
        #endregion
        #region QueryInsert
        const string INSERT_AULA = @"INSERT INTO dbo.aula (id, nome, capacita_massima, fisica, computerizzata, proiettore)
                                         VALUES (@id, @nome, @capacita_massima, @fisica, @computerizzata, @proiettore);";
            const string INSERT_AZIENDA = @"INSERT INTO dbo.azienda (id, nome, citta, indirizzo, cap, telefono, email, partita_iva)
                                             VALUES (@id, @nome, @citta, @indirizzo, @cap, @telefono, @email, @partita_iva);";
            const string INSERT_CATEGORIA = @"INSERT INTO dbo.categoria (id, descrizione, argomento)
                                            VALUES (@id, @descrizione, @argomento);";
            const string INSERT_FINANZIATORE = @"INSERT INTO dbo.finanziatore (id, descrizione)
                                                VALUES (@id, @descrizione);";
            const string INSERT_LIVELLO = @"INSERT INTO dbo.livello (id, descrizione, tipo)
                                            VALUES (@id, @descrizione, @tipo);";
            const string INSERT_CORSO = @"INSERT INTO dbo.corso (id, titolo, ammontare_ore, costo_di_riferimento, id_progetto, id_livello, id_categoria)
                                                VALUES (@id, @titolo, @ammontare_ore, @costo_di_riferimento, @id_progetto, @id_livello, @id_categoria);";
            const string INSERT_EDIZIONE = @"INSERT INTO dbo.edizione (id, codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, id_presenza, id_aula, id_corso, id_finanziatore)
                                                    VALUES (@id, @codice_edizione, @data_inizio, @data_fine, @prezzo_finale, @numero_studenti_massimo, @id_presenza, @id_aula, @id_corso, @id_finanziatore);";
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
                            string titolo = reader.GetString("nome");
                            string descrizione = reader.GetString("descrizione");
                            int ammontare_ore = reader.GetInt32("ammontare_ore");
                            decimal costo_di_riferimento = reader.GetDecimal("costo_di_riferimento");
                            int id_livello = reader.GetInt32("id_livello");
                            int id_progetto = reader.GetInt32("id_progetto");
                            int id_categoria = reader.GetInt32("id_categoria");
                            cr = new Corso( idCorso,  titolo, ammontare_ore, (long)costo_di_riferimento, id_livello, id_progetto, id_categoria, descrizione);
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
        public void SetCourse(Corso corso)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_CORSO, conn);
                    cmd.Parameters.AddWithValue("@id", corso.Id);
                    cmd.Parameters.AddWithValue("@nome", corso.Titolo);
                    cmd.Parameters.AddWithValue("@descrizione", corso.Descrizione);
                    cmd.Parameters.AddWithValue("@ammontare_ore", corso.AmmontareOre);
                    cmd.Parameters.AddWithValue("@costo_di_riferimento", corso.CostoDiRiferimento);
                    cmd.Parameters.AddWithValue("@id_livello", corso.IdLivello);
                    cmd.Parameters.AddWithValue("@id_progetto", corso.IdProgetto);
                    cmd.Parameters.AddWithValue("@id_categoria", corso.IdCategoria);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public IEnumerable<Corso> GetCourses()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region EdizioneCorsi
        public void SetEdition(EdizioneCorso edizione)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                 
                    SqlCommand cmd = new SqlCommand(INSERT_EDIZIONE, conn);
                    cmd.Parameters.AddWithValue("@id", edizione.Id);
                    cmd.Parameters.AddWithValue("@codice_edizione", edizione.CodiceEdizione);
                    cmd.Parameters.AddWithValue("@data_inizio", edizione.Start);
                    cmd.Parameters.AddWithValue("@data_fine", edizione.End);
                    cmd.Parameters.AddWithValue("@prezzo_finale", edizione.RealPrice);
                    cmd.Parameters.AddWithValue("@numero_studenti_massimo", edizione.NumStudents);
                    //cmd.Parameters.AddWithValue("@id_presenza", edizione.IdProgetto);
                    cmd.Parameters.AddWithValue("@id_aula", edizione.IdAula);
                    cmd.Parameters.AddWithValue("@id_corso", edizione.IdCorso);
                    cmd.Parameters.AddWithValue("@id_finanziatore", edizione.IdFinanziatore);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId)
        {
            throw new NotImplementedException();
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
                        return cl;
                    }
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
                            string tipo = reader.GetString("tipo");
                            lv = new Livello((int)idLivello, descrizione, tipo);
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
        public Progetto GetProgettobyid(long idProgetto)
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
                            int idAzienda = reader.GetInt32("idAzienda");
                            string tipo = reader.GetString("tipo");                           
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
        public void SetAula(Aula aula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_AULA, conn);
                    cmd.Parameters.AddWithValue("@id", aula.Id);
                    cmd.Parameters.AddWithValue("@nome", aula.Name);
                    cmd.Parameters.AddWithValue("@capacita_massima", aula.MaxCapacity);
                    cmd.Parameters.AddWithValue("@fisica", aula.IsPhysical);
                    cmd.Parameters.AddWithValue("@computerizzata", aula.IsComputerized);
                    cmd.Parameters.AddWithValue("@proiettore", aula.HasProjector);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: "+e.Message);               
            }
        }
        public void SetAzienda(Azienda azienda)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_AZIENDA, conn);
                    cmd.Parameters.AddWithValue("@id", azienda.Id);
                    cmd.Parameters.AddWithValue("@nome", azienda.Nome);
                    cmd.Parameters.AddWithValue("@citta", azienda.Citta);
                    cmd.Parameters.AddWithValue("@indirizzo", azienda.Indirizzo);
                    cmd.Parameters.AddWithValue("@cap", azienda.Cap);
                    cmd.Parameters.AddWithValue("@telefono", azienda.Telefono);
                    cmd.Parameters.AddWithValue("@email", azienda.Email);
                    cmd.Parameters.AddWithValue("@partita_iva", azienda.PartitaIva);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public void SetCategoria(Categoria categoria)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_CATEGORIA, conn);
                    cmd.Parameters.AddWithValue("@id", categoria.Id);
                    cmd.Parameters.AddWithValue("@descrizione", categoria.Descrizione);
                    cmd.Parameters.AddWithValue("@argomento", categoria.Argomento);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public void SetFinanziatore(Finanziatore finanziatore)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_FINANZIATORE, conn);
                    cmd.Parameters.AddWithValue("@id", finanziatore.Id);
                    cmd.Parameters.AddWithValue("@descrizione", finanziatore.Descrizione);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public void SetLivello(Livello level)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_LIVELLO, conn);
                    cmd.Parameters.AddWithValue("@id", level.Id);
                    cmd.Parameters.AddWithValue("@descrizione", level.Descrizione);
                    cmd.Parameters.AddWithValue("@argomento", level.Tipo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public void SetProgetto(Progetto progetto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_LIVELLO, conn);
                    cmd.Parameters.AddWithValue("@id", progetto.Id);
                    cmd.Parameters.AddWithValue("@descrizione", progetto.Descrizione);
                    cmd.Parameters.AddWithValue("@id_azienda", progetto.IdAzienda);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        #endregion
    }
}
