/// \file ExcecaoValidarApartamento.cs
/// \brief Classe que contem exceçoes da classe ValidarApartamentos
/// \details Esta classe contem um dicionario com as exceções da validação de atributos do apartamento.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoValidarApartamento
    /// \brief Classe que representa exceçoes especificas para a validação de atributos do apartamento
    public class ExcecaoValidarApartamento : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para a validação de atributos do apartamento.
        private static readonly Dictionary<int, string> ApartamentoErros = new Dictionary<int, string>()
        {
            { 1, "ID cant be 0 or lower." },
            { 2, "Invalid Address." },
            { 3, "Invalid Price." },
            { 4, "Invalid Capacity." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoValidarApartamento com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoValidarApartamento(int error) : base(ApartamentoErros.ContainsKey(error) ? ApartamentoErros[error] : "Unknown Error")
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
