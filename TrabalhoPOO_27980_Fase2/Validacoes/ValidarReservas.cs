/// \file ValidarReservas.cs
/// \brief Classe para validar dados ao criar uma reserva ou atualiza-la.
/// \details Esta classe permite validar dados da reserva.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Excecoes;

namespace Validacoes
{
    /// \class ValidarReservas
    /// \brief Classe para validar reservas.
    public class ValidarReservas
    {

        /// <summary>
        /// \brief Metodo para validar uma reserva.
        /// </summary>
        /// <param name="id">ID da reserva</param>
        /// <param name="DataInicio">Data de início da reserva</param>
        /// <param name="DataFim">Data final da reserva</param>
        /// <param name="hospedes">Número total de hóspedes</param>
        /// <returns>True se a reserva for válida, caso contrário, false</returns>
        public static bool ValidarReserva(int id, DateTime DataInicio, DateTime DataFim, int hospedes)
        {
            if (ValidarID(id) != true)
            {
                return false;
            }

            if (ValidarDataInicio(DataInicio) != true)
            {
                return false;
            }

            if (ValidarDataFim(DataFim, DataInicio) != true)
            {
                return false;
            }

            if (ValidarHospedes(hospedes) != true)
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
                throw new ExcecaoValidarReserva(1);
            }
            return true;
        }

        public static bool ValidarDataInicio(DateTime DataInicio)
        {
            if (DataInicio < DateTime.Now)
            {
                throw new ExcecaoValidarReserva(2);
            }
            return true;
        }

        public static bool ValidarDataFim(DateTime DataFim, DateTime DataInicio)
        {
            if (DataFim <= DataInicio)
            {
                throw new ExcecaoValidarReserva(3);
            }
            return true;
              
        }

        public static bool ValidarHospedes(int h)
        {
            if (h <= 0)
            {
                throw new ExcecaoValidarReserva(4);
            }
            return true;
        }

        #endregion
    }
}
