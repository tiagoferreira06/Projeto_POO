/// \file AlojamentoBase.cs
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosDeNegocio
{
    /// \class AlojamentoBase
    /// \brief Classe que representa um alojamento base.
    [Serializable]
    public class AlojamentoBase
    {
        #region Attributes

        /// \brief Identificador unico do alojamento.
        private int id;

        /// \brief Nome do alojamento.
        private string nome;

        /// \brief Endereco do alojamento.
        private string endereco;

        /// \brief Valor da diaria no alojamento.
        private double valorDiaria;

        #endregion

        #region Constructors

        /// \brief Default Constructor.
        public AlojamentoBase()
        {
        }

        /// <summary>
        /// \brief Construtor com parâmetros.
        /// </summary>
        /// <param name="id">Identificador único do alojamento.</param>
        /// <param name="nome">Nome do alojamento.</param>
        /// <param name="endereco">Endereço do alojamento.</param>
        /// <param name="valorDiaria">Valor diário.</param>
        public AlojamentoBase(int id, string nome, string endereco, double valorDiaria)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            ValorDiaria = valorDiaria;
        }

        #endregion

        #region Properties

        /// \brief Propriedade para o ID do alojamento.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// \brief Propriedade para o nome do alojamento.
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// \brief Propriedade para o endereço do alojamento.
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        /// \brief Propriedade para o valor diario no alojamento.
        public double ValorDiaria
        {
            get { return valorDiaria; }
            set { valorDiaria = value; }
        }

        #endregion

        #region Methods


        #endregion
    }
}
