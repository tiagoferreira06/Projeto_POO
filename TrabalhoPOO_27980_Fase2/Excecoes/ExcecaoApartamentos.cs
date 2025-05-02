/// \file ExcecaoApartamento.cs
/// \brief Classe que contem exceçoes da classe Apartamentos.cs
/// \details Esta classe contem um dicionario com as exceções da gestão de apartamentos.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoApartamentos
    /// \brief Classe que representa exceçoes especificas para a gestão de apartamentos.
    public class ExcecaoApartamento : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para a gestão de apartamentos.
        private static readonly Dictionary<int, string> ApartamentoErros = new Dictionary<int, string>()
        {
            { 1, "Apartment already exists." },
            { 2, "Apartment do not exist." },
            { 3, "Apartment unavailable." },
            { 4, "Invalid ID." },
            { 5, "Invalid Name." },
            { 6, "Invalid File Name." }

        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoApartamentos com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoApartamento(int error) : base(ApartamentoErros.ContainsKey(error) ? ApartamentoErros[error] : "Unknown Error")
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
