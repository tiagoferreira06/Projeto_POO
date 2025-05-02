/// \file ExcecaoReservaRegras.cs
/// \brief Classe que contem exceçoes da classe RegrasReservas.cs
/// \details Esta classe contem um dicionario com as exceções das regras de negocio das reservas.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoReservaRegras
    /// \brief Classe que representa exceções específicas para regras de reservas.
    public class ExcecaoReservaRegras : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para as regras de reservas.
        private static readonly Dictionary<int, string> ReservaRegrasErros = new Dictionary<int, string>()
        {
            { 1, "Invalid Permission." },
            { 2, "Couldn't create reservation." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoReservaRegras com parâmetro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoReservaRegras(int error) : base(ReservaRegrasErros.ContainsKey(error) ? ReservaRegrasErros[error] : "Unknown Error")
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
