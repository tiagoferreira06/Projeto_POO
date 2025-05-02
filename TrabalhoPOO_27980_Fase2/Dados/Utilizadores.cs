/// \file Utilizadores.cs
/// \brief Classe para gerir utilizadores do sistema.
/// \details Esta classe permite criar, atualizar, remover informações sobre utilizadores.
/// \author Tiago Ferreira
/// \date 2024


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using ObjetosDeNegocio;
using Excecoes;
using Validacoes;

namespace Dados

{
    /// \class Utilizadores
    /// \brief Classe para gerir operações relacionadas a utilizadores.
    public class Utilizadores
    {
        #region Attributes

        /// \brief Lista de Utilizadores.

        private static List<Utilizador> ListaUtilizadores = new List<Utilizador>();

        #endregion

        #region Methods

        /// \brief Cria um novo utilizador.
        /// \param id Identificador unico do utilizador.
        /// \param perm Permissão atríbuida ao utilizador (1: básico, 2: moderador, 3: administrador).
        /// \param nome Nome do utilizador.
        /// \param contato Contato do utilizador.
        /// \return Retorna true se o utilizador foi criado com sucesso.
        /// \throws ExcecaoUtilizadores Caso o ID seja duplicado.
        public static bool CriarUser(int id, int perm, string nome, string contato)
        {
            //Verificar se ja existe um utilizador com o ID.
            if (BuscarUserPorId(id) != null)
            {
                throw new ExcecaoUtilizadores(1);
            }

            // Validar se os atributos estao corretos.  
            if (ValidarUsers.ValidarUser(id, perm, nome, contato) == false)
            {
                return false;
            }

            // Criar novo utilizador por meio da funcao no objeto e adiciona-lo a lista.
            Utilizador novo = Utilizador.CriarUser(id, perm, nome, contato);
            AdicionarUser(novo);
            return true;

        }

        /// \brief Busca um utilizador pelo ID.
        /// \param id Identificador unico do utilizador.
        /// \return O utilizador correspondente ou null se nao encontrado.
        public static Utilizador BuscarUserPorId(int id)
        {
            foreach (Utilizador u in ListaUtilizadores)
            {
                if (u.Id == id) return u;
            }
            return null;

        }

        /// \brief Adiciona um utilizador à lista.
        /// \param u Objeto do tipo Utilizador.
        /// \return Retorna true se o utilizador foi adicionado com sucesso.
        /// \throws ExececaoUtilizadores Caso o utilizador seja nulo.
        public static bool AdicionarUser(Utilizador u)
        {
            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }
            ListaUtilizadores.Add(u);
            return true;
        }

        /// \brief Remove um utilizador pelo ID.
        /// \param id Identificador unico do utilizador.
        /// \return Retorna true se o utilizador foi removido com sucesso.
        /// \throws ExececaoUtilizadores Caso o utilizador nao seja encontrado.
        public static bool RemoverUser(int id)
        {
            Utilizador u = BuscarUserPorId(id);
            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }
            else
            {
                ListaUtilizadores.Remove(u);
                return true;
            }
        }

        /// \brief Atualiza os dados de um utilizador.
        /// \param id Identificador do utilizador a ser atualizado.
        /// \param idNovo Novo identificador do utilizador.
        /// \param perm Nova permissão associada ao utilizador.
        /// \param nome Novo nome do utilizador.
        /// \param contato Novo contato do utilizador.
        /// \return Retorna true se os dados foram atualizados com sucesso.
        /// \throws ExececaoUtilizadores Caso o utilizador ou identificadores sejam inválidos.
        public static bool AtualizarUser(int id, int idNovo, int perm, string nome, string contato)
        {
            Utilizador u = BuscarUserPorId(id);
            Utilizador u2 = BuscarUserPorId(idNovo);

            if (ValidarUsers.ValidarUser(idNovo, perm, nome, contato) == false)
            {
                return false;
            }

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }
            if (u2 != null)
            {
                throw new ExcecaoUtilizadores(4);
            }


            u.Id = idNovo;
            u.Perm = perm;
            u.Contato = contato;
            u.Nome = nome;
            return true;

        }

        #region Ficheiros

        /// \brief Guarda a lista de utilizadores num ficheiro binário.
        /// \param ficheiro Nome do ficheiro onde os dados serão salvos.
        /// \return Retorna true se os dados forem guardados com sucesso.
        /// \throws ExcecaoUtilizadores Caso o nome do ficheiro seja nulo ou esteja vazio.
        public static bool GuardarUsersFicheiro(string ficheiro)
        {
            if (ficheiro == "" || ficheiro == null)
            {
                throw new ExcecaoUtilizadores(6);
            }

            Stream stream = File.Open(ficheiro, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, ListaUtilizadores);
            stream.Close();

            return true;
        }

        /// \brief Le a lista de utilizadores de um ficheiro binário.
        /// \param ficheiro Nome do ficheiro de onde os dados serão lidos.
        /// \return Retorna true se os dados forem carregados com sucesso.
        /// \throws ExcecaoUtilizadores Caso o nome do ficheiro seja null ou esteja vazio.
        public static bool LerUsersFicheiro(string ficheiro)
        {
            if (ficheiro == "" || ficheiro == null)
            {
                throw new ExcecaoUtilizadores(6);
            }

            Stream stream = File.Open(ficheiro, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            ListaUtilizadores = (List<Utilizador>)bin.Deserialize(stream);
            stream.Close();

            return true;

        }

        #endregion

        #endregion
    }
}
