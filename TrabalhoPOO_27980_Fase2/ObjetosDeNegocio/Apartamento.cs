/// \file Apartamento.cs
/// \brief Classe para representar um apartamento.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosDeNegocio
{
    /// \class Apartamento
    /// \brief Classe que representa um apartamento.
    [Serializable]
    public class Apartamento : AlojamentoBase
    {
        #region Attributes

        /// \brief Indica a quantidade de hospedes aceite no apartamento.
        private int capacidade;

        /// \brief Indica se esta disponivel ou nao, o apartamento.
        private bool disponivel;

        /// \brief Indica se esta disponivel ou nao, o apartamento.
        private bool possuiWifi;

        #endregion

        #region Constructors

        /// \brief Default Constructor.
        public Apartamento() 
        {
            
        }

        /// <summary>
        /// \brief Construtor do Apartamento com parametros.
        /// </summary>
        /// <param name="id">ID do apartamento</param>
        /// <param name="nome">Nome do apartamento</param>
        /// <param name="endereco">Endereço do apartamento</param>
        /// <param name="valorDiaria">Valor da diária do apartamento</param>
        /// <param name="capacidade">Capacidade de hóspedes do apartamento</param>
        /// <param name="disponivel">Disponibilidade do apartamento</param>
        /// <param name="possuiWifi">Indica se o apartamento possui Wi-Fi</param>
        public Apartamento(int id, string nome, string endereco, double valorDiaria, int capacidade, bool disponivel, bool possuiWifi)
            : base(id, nome, endereco, valorDiaria)
        {
            Capacidade = capacidade;
            PossuiWifi = possuiWifi;
            Disponivel = disponivel;
        }

        #endregion

        #region Properties
        /// \brief Propriedade para capacidade do apartamento.
        public int Capacidade
        {
            get { return capacidade; }
            set { capacidade = value; }
        }

        /// \brief Propriedade para Wi-Fi do Apartamento.
        public bool PossuiWifi
        {
            get { return possuiWifi; }
            set { possuiWifi = value; }
        }

        /// \brief Propriedade para Disponibilidade do Apartamento.
        public bool Disponivel
        {
            get { return disponivel; }
            set { disponivel = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// \brief Metodo static para criar um novo apartamento.
        /// </summary>
        /// <param name="id">ID do apartamento</param>
        /// <param name="nome">Nome do apartamento</param>
        /// <param name="endereco">Endereço do apartamento</param>
        /// <param name="valorDiaria">Valor da diária do apartamento</param>
        /// <param name="c">Capacidade de hóspedes do apartamento</param>
        /// <param name="disponivel">Disponibilidade do apartamento</param>
        /// <param name="possuiWifi">Indica se o apartamento possui Wi-Fi</param>
        /// <returns>Um novo objeto Apartamento</returns>
        public static Apartamento CriarApartamento(int id, string nome, string endereco, double valorDiaria, int c, bool disponivel, bool possuiWifi)
        {
            Apartamento ap = new Apartamento(id, nome, endereco, valorDiaria, c, disponivel, possuiWifi);
            return ap;
        }


        #endregion

    }
}
