/// \file Utilizador.cs
/// \brief Classe para representar um utilizador.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosDeNegocio
{
    /// \class Utilizador
    /// \brief Classe que representa um utilizador.
    [Serializable]
    public class Utilizador
    {
        #region Attributes

        /// \brief Identificador unico do utilizador.
        private int id;

        /// \brief Permissoes do utilizador. 1-Utilizador, 2 - Moderador, 3 - Administrador
        private int perm;

        /// \brief Nome do utilizador.
        private string nome;

        /// \brief Informacoes de contacto do utilizador.
        private string contato;

        #endregion

        #region Constructors


        /// \brief The Default Constructor.
        public Utilizador()
        {

        }

        /// <summary>
        /// /brief Construtor de Utilizador com parametros.
        /// </summary>
        /// <param name="id">Id do Utilizador</param>
        /// <param name="perm">Permissao do utilizador(1,2 ou 3)</param>
        /// <param name="nome">Nome do utilizador</param>
        /// <param name="contato">Contato do utilizador</param>
        public Utilizador(int id, int perm, string nome, string contato)
        {
            Id = id;
            Perm = perm;
            Nome = nome;
            Contato = contato;

        }

        #endregion

        #region Properties

        /// \brief Propriedade para o identificador unico do utilizador.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// \brief Propiedade para as permissoes associadas ao utilizador.
        public int Perm
        {
            get { return perm; }
            set { perm = value; }
        }

        /// \brief Propriedade para o nome do utilizador.
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// \brief Propriedade para o contacto do utilizador.
        public string Contato
        {
            get { return contato; }
            set { contato = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// \brief Metodo para criar novo utilizador.
        /// </summary>
        /// <param name="id">Id do Utilizador</param>
        /// <param name="perm">Permissao do utilizador(1,2 ou 3)</param>
        /// <param name="nome">Nome do utilizador</param>
        /// <param name="contato">Contato do utilizador</param>
        /// <returns>Objeto utilizador</returns>
        public static Utilizador CriarUser(int id, int perm, string nome, string contato)
        {
            Utilizador user = new Utilizador(id, perm, nome, contato);
            return user;
        }

        #endregion
    }
}
