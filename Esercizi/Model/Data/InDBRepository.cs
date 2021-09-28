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
        const string CONNECTION_STRING = @"Server = localhost;             
                                        User=sa;             
                                        Password=1Secure*Password;             
                                        Database = scuola";
        const string SELECT_AULA = @"Select id, nome, capacita_massima,fisica,computerizzata, proiettore
                                    From dbo.aula
                                    where @id=id";
        #endregion

        #region Corsi
        public bool CourseExists(Corso c)
        {
            throw new NotImplementedException();
        }
        public Corso GetCourseById(long id)
        {
            throw new NotImplementedException();
        }
        public Corso AddCourse(Corso c)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Corso> GetCourses()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region EdizioneCorsi
        public EdizioneCorso AddEdition(EdizioneCorso e)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public Categoria GetCategoriabyId(long idCategoria)
        {
            throw new NotImplementedException();
        }
        public Finanziatore GetFinanziatorebyId(long idFinanziatore)
        {
            throw new NotImplementedException();
        }
        public Livello GetLivellobyId(long idLivello)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Set
        public void SetAula(Aula aula)
        {
            throw new NotImplementedException();
        }
        public void SetAzienda(Azienda aziend)
        {
            throw new NotImplementedException();
        }
        public void SetCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
        public void SetFinanziatore(Finanziatore finanziatore)
        {
            throw new NotImplementedException();
        }
        public void SetLivello(Livello level)
        {
            throw new NotImplementedException();
        }
        #endregion





    }
}
