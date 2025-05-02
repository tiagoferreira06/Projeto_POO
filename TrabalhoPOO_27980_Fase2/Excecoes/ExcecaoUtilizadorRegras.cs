/// \file ExcecaoUtilizadorRegras.cs
/// \brief Classe que contem exceçoes da classe RegrasUtilizadores.cs
/// \details Esta classe contem um dicionario com as exceções das regras de negocio dos utilizadores.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    /// \class ExcecaoUtilizadoresRegras
    /// \brief Classe que representa exceções específicas para regras de utilizadores.
    public class ExcecaoUtilizadorRegras : ApplicationException
    {
        #region Attributes

        /// \brief Código do erro.
        private int codigoErro;

        #endregion

        /// \brief Dicionário que contem as mensagens de erro para as regras de utilizadores.
        private static readonly Dictionary<int, string> UtilizadorRegrasErros = new Dictionary<int, string>()
        {
            { 1, "Invalid Permission." }
        };

        #region Constructors

        /// <summary>
        /// \brief Construtor da classe ExcecaoUtilizadorRegras com parâmetro de erro.
        /// </summary>
        /// <param name="error">Código do erro</param>
        public ExcecaoUtilizadorRegras(int error) : base(UtilizadorRegrasErros.ContainsKey(error) ? UtilizadorRegrasErros[error] : "Unknown Error")
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
