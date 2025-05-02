/// \file ValidarApartamentos.cs
/// \brief Classe para validar dados ao criar um apartamento ou atualiza-lo.
/// \details Esta classe permite validar dados do apartamento.
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
    /// \class ValidarApartamentos
    /// \brief Classe para validar atributos do apartamentos.
    public class ValidarApartamentos
    {

        /// <summary>
        /// \brief Metodo para validar um apartamento.
        /// </summary>
        /// <param name="id">ID do apartamento</param>
        /// <param name="nome">Nome do apartamento</param>
        /// <param name="endereco">Endereço do apartamento</param>
        /// <param name="valorDiaria">Valor da diária do apartamento</param>
        /// <param name="c">Capacidade de hóspedes do apartamento</param>
        /// <returns>True se o apartamento for válido, caso contrário, false</returns>
        public static bool ValidarApartamento(int id, string nome, string endereco, double valorDiaria, int c)
        {
            if (ValidarID(id) != true)
            {
                return false;
            }

            if (ValidarEndereco(endereco) != true)
            {
                return false;
            }

            if (ValidarValorDiaria(valorDiaria) != true)
            {
                return false;
            }

            if (ValidarCapacidade(c) != true)
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
                throw new ExcecaoValidarApartamento(1);
            }
            return true;
        }

        public static bool ValidarEndereco(string endereco)
        {
            if (endereco == null)
            {
                throw new ExcecaoValidarApartamento(2);
            }
            return true;
        }

        public static bool ValidarValorDiaria(double valorDiaria)
        {
            if (valorDiaria < 0)
            {
                throw new ExcecaoValidarApartamento(3);
            }
            return true;
        }
        public static bool ValidarCapacidade(int c)
        {
            if (c <= 0)
            {
                throw new ExcecaoValidarApartamento(4);
            }
            return true;
        }

        #endregion
    }
}
