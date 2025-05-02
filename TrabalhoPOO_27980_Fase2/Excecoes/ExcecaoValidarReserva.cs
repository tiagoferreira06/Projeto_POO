/// \file ExcecaoValidarReserva.cs
/// \brief Classe que contem exceçoes da classe ValidarReservas
/// \details Esta classe contem um dicionario com as exceções da validação de atributos da reserva.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoValidarReserva
    /// \brief Classe que representa exceçoes especificas para a validação de atributos da reserva
    public class ExcecaoValidarReserva : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para a validação de atributos da reserva.
        private static readonly Dictionary<int, string> ReservaErros = new Dictionary<int, string>()
        {
            { 1, "ID cant be 0 or lower." },
            { 2, "A reservation can't start before today. (Invalid Data)" },
            { 3, "The end of a reservation cant be earlier or equal than the beginning." },
            { 4, "Invalid Persons." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoValidarReserva com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoValidarReserva(int error) : base(ReservaErros.ContainsKey(error) ? ReservaErros[error] : "Unknown Error")
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
