/// \file ExcecaoValidarUser.cs
/// \brief Classe que contem exceçoes da classe ValidarUsers
/// \details Esta classe contem um dicionario com as exceções da validação de atributos do utilizador.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoValidarUser
    /// \brief Classe que representa exceçoes especificas para a validação de atributos do utilizador
    public class ExcecaoValidarUser : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para a validação de atributos do utilizador.
        private static readonly Dictionary<int, string> UserErros = new Dictionary<int, string>()
        {
            { 1, "ID cant be 0 or lower." },
            { 2, "Permission must be between 1 and 3." },
            { 3, "Invalid Name." },
            { 4, "Invalid Contact." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoValidarUser com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoValidarUser(int error) : base(UserErros.ContainsKey(error) ? UserErros[error] : "Unknown Error")
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
