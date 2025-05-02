/// \file RegrasUtilizadores.cs
/// \brief Classe para gerir as regras de permissões relacionadas aos utilizadores.
/// \details Esta classe define regras específicas para criar, atualizar, remover e guardar utilizadores.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excecoes;
using ObjetosDeNegocio;
using Dados;

namespace RegrasDeNegocio
{

    /// \class RegrasUtilizadores
    /// \brief Classe estatica para gerir regras de acesso e permissões dos utilizadores.
    public static class RegrasUtilizadores
    {

        #region PermissoesUtilizadores

        /// \brief Tenta criar um novo utilizador com base nas permissões do utilizador atual.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param id Identificador unico do novo utilizador.
        /// \param perm Permissão do novo utilizador (1: básico, 2: moderador, 3: administrador).
        /// \param nome Nome do novo utilizador.
        /// \param contato Contato do novo utilizador.
        /// \return Retorna true se o utilizador foi criado com sucesso.
        /// \throws ExececaoUtilizadorRegras Caso o utilizador atual não tenha permissão para criar.
        public static bool TentaCriarUser(int idU, int id, int perm, string nome, string contato)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm == 3)
            {
                if (Utilizadores.CriarUser(id, perm, nome, contato) == true)
                {
                    return true;
                }
                return false;
            }
            throw new ExcecaoUtilizadorRegras(1);

        }

        /// \brief Tenta atualizar os dados de um utilizador com base nas permissões do utilizador atual.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param id Identificador do utilizador a ser atualizado.
        /// \param idNovo Novo identificador do utilizador.
        /// \param perm Nova permissão associada ao utilizador.
        /// \param nome Novo nome do utilizador.
        /// \param contato Novo contato do utilizador.
        /// \return Retorna true se o utilizador foi atualizado com sucesso.
        /// \throws ExececaoUtilizadorRegras Caso o utilizador atual não tenha permissão para atualizar.
        public static bool TentaAtualizarUser(int idU, int id, int idNovo, int perm, string nome, string contato)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm == 3)
            {
                if (Utilizadores.AtualizarUser(id, idNovo, perm, nome, contato) == true)
                {
                    return true;
                }
                return false;
            }
            throw new ExcecaoUtilizadorRegras(1);
        }

        /// \brief Tenta remover um utilizador com base nas permissões do utilizador atual.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param id Identificador do utilizador a ser removido.
        /// \return Retorna true se o utilizador foi removido com sucesso.
        /// \throws ExececaoUtilizadorRegras Caso o utilizador atual não tenha permissão para remover ou tente remover alguém com nível de permissão igual ou superior.
        public static bool TentaRemoverUser(int idU, int id)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm == 3 || u.Perm == 2)
            {
                Utilizador uRemover = Utilizadores.BuscarUserPorId(id);
                if (uRemover.Perm >= u.Perm)
                {
                    throw new ExcecaoUtilizadorRegras(1);
                }
                else
                {
                    Utilizadores.RemoverUser(id);
                    return true;
                }
            }
            throw new ExcecaoUtilizadorRegras(1);
        }

        /// \brief Guarda os utilizadores num ficheiro, desde que o utilizador atual tenha permissão.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param fileName Nome do ficheiro onde os dados serão salvos.
        /// \return Retorna true se os dados foram guardados com sucesso.
        /// \throws ExececaoUtilizadorRegras Caso o utilizador atual não tenha permissão para guardar.
        public static bool TentaGuardarUtilizadoresFicheiro(int idU, string fileName)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoUtilizadorRegras(1);
            }
            else
            {
                Utilizadores.GuardarUsersFicheiro(fileName);
                return true;
            }
        }

        /// \brief Le os utilizadores num ficheiro, desde que o utilizador atual tenha permissão.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param fileName Nome do ficheiro onde os dados serão lidos.
        /// \return Retorna true se os utilizadores foram lidos com sucesso.
        /// \throws ExececaoUtilizadorRegras Caso o utilizador não tenha permissão para ler.
        public static bool TentaLerUtilizadoresFicheiro(int idU, string fileName)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoUtilizadorRegras(1);
            }
            else
            {
                Utilizadores.LerUsersFicheiro(fileName);
                return true;
            }
        }

        #endregion

    }
}
