/// \file ValidarUsers.cs
/// \brief Classe para validar dados ao criar um utilizador ou atualiza-lo.
/// \details Esta classe permite validar dados do utilizador.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excecoes;

namespace Validacoes
{
    public class ValidarUsers
    {
        public static bool ValidarUser(int id, int perm, string nome, string contato)
        {
            if (ValidarID(id) != true)
            {
                return false;
            }

            if (ValidarPerm(perm) != true)
            {
                return false;
            }

            if (ValidarNome(nome) != true)
            {
                return false;
            }

            if (ValidarContato(contato) != true)
            {
                return false;
            }

            return true;
        }

        #region Validações Específicas

        public static bool ValidarID(int id)
        {
            if (id <= 0)
            {
                throw new ExcecaoValidarUser(1);
            }
            return true;
        }
        public static bool ValidarPerm(int perm)
        {
            if (perm > 3 || perm < 1)
            {
                throw new ExcecaoValidarUser(2);
            }
            return true;
        }

        public static bool ValidarNome(string nome)
        {
            if (nome == null)
            {
                throw new ExcecaoValidarUser(3);
            }
            return true;
        }

        public static bool ValidarContato(string contato)
        {
            if (contato == null)
            {
                throw new ExcecaoValidarUser(4);
            }
            return true;
        }

        #endregion
    }
}
