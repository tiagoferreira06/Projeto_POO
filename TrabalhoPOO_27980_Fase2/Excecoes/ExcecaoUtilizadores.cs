/// \file ExcecaoUtilizadores.cs
/// \brief Classe que contem exceçoes da classe Utilizadores.cs
/// \details Esta classe contem um dicionario com as exceções da gestão de utilizadores.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoUtilizadores
    /// \brief Classe que representa exceçoes especificas para a gestão de utilizadores.
    public class ExcecaoUtilizadores : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para a gestão de utilizadores.
        private static readonly Dictionary<int, string> UtilizadoresErros = new Dictionary<int, string>()
        {
            { 1, "User already exists." },
            { 2, "User do not exist." },
            { 3, "Invalid Permission." },
            { 4, "Cant create user with that ID because one already exists." },
            { 5, "Invalid ID." },
            { 6, "Invalid File Name." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoUtilizadores com parametro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoUtilizadores(int error) : base(UtilizadoresErros.ContainsKey(error) ? UtilizadoresErros[error] : "Unknown Error")
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
