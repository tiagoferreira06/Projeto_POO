/// \file ExcecaoReservas.cs
/// \brief Classe que contem exceçoes da classe Reservas.cs
/// \details Esta classe contem um dicionario com as exceções da gestão de reservas.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoReservas
    /// \brief Classe que representa exceçoes especificas para a gestão de reservas.
    public class ExcecaoReservas : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para a gestão de reservas.
        private static readonly Dictionary<int, string> ReservasErros = new Dictionary<int, string>()
        {
            { 1, "Reservation already exists." },
            { 2, "Reservation do not exist." },
            { 3, "Invalid ID" },
            { 4, "Number of clients exceded." },
            { 5, "Invalid File Name." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoReservas com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoReservas(int error) : base(ReservasErros.ContainsKey(error) ? ReservasErros[error] : "Unknown Error")
        {
            CodigoErro = error;
            Console.WriteLine("\nError: " + CodigoErro + " -> " + Message);
        }

        #endregion

        #region Properties

        /// \brief Propriedade para o código do erro.
        public int CodigoErro
        {
            get { return codigoErro; }
            set { codigoErro = value; }
        }

        #endregion
    }
}
