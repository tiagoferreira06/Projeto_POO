/// \file ExcecaoApartamentoRegras.cs
/// \brief Classe que contem exceçoes da classe RegrasApartamentos.cs
/// \details Esta classe contem um dicionario com as exceções das regras de negocio dos apartamentos.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoApartamentoRegras
    /// \brief Classe que representa exceçoes especificas para regras de apartamentos.
    public class ExcecaoApartamentoRegras : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para as regras de apartamentos.
        private static readonly Dictionary<int, string> ApartamentoRegrasErros = new Dictionary<int, string>()
        {
            { 1, "Invalid Permission." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoApartamentoRegras com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoApartamentoRegras(int error) : base(ApartamentoRegrasErros.ContainsKey(error) ? ApartamentoRegrasErros[error] : "Unknown Error")
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
