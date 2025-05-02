/// \file Reserva.cs
/// \brief Classe para representar uma reserva.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;


namespace ObjetosDeNegocio
{
    /// \class Reserva
    /// \brief Classe que representa uma reserva.
    [Serializable]
    public class Reserva
    {
        #region Attributes
        /// \brief Identificador unico da reserva.
        private int id;

        /// \brief Data Inicio da Reserva.
        private DateTime dataInicio;

        /// \brief Data Final da Reserva.
        private DateTime dataFim;

        /// \brief Numero total de hospedes.
        private int hospedes;

        /// \brief Status da reserva (cancelada/nao cancelada).
        private bool status;

        Utilizador u;
        Apartamento ap;

        #endregion

        #region Constructors


        /// \brief The Default Constructor.
        public Reserva()
        {

        }

        /// <summary>
        /// \brief Construtor da Reserva com parametros.
        /// </summary>
        /// <param name="id">ID da reserva</param>
        /// <param name="ap">Apartamento associado</param>
        /// <param name="u">Utilizador associado</param>
        /// <param name="dataInicio">Data Inicial da Reserva</param>
        /// <param name="dataFim">Data Final da Reserva</param>
        /// <param name="hospedes">Numero total de hospedes</param>
        /// <param name="status">Status da reserva</param>
        public Reserva(int id, Apartamento ap, Utilizador u, DateTime dataInicio, DateTime dataFim, int hospedes, bool status)
        {
            Id = id;
            U = u;
            Ap = ap;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Hospedes = hospedes;
            Status = status;
        }

        #endregion

        #region Properties

        /// \brief Propriedade para o utilizador associado a reserva.
        public Utilizador U
        {
            get { return u; }
            set { u = value; }
        }

        /// \brief Propriedade para o apartamento associado a reserva.
        public Apartamento Ap
        {
            get { return ap; }
            set { ap = value; }
        }

        /// \brief Propriedade para o ID da reserva.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// \brief Propriedade para a data de início.
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        /// \brief Propriedade para a data final.
        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }

        /// \brief Propriedade para o número total de hóspedes.
        public int Hospedes
        {
            get { return hospedes; }
            set { hospedes = value; }
        }

        /// \brief Propriedade para o status da reserva.
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// \brief Método static para criar uma nova reserva.
        /// </summary>
        /// <param name="id">ID da reserva</param>
        /// <param name="ap">Apartamento associado</param>
        /// <param name="u">Utilizador associado</param>
        /// <param name="DataInicio">Data inicial da reserva</param>
        /// <param name="DataFim">Data final da reserva</param>
        /// <param name="hospedes">Número total de hóspedes</param>
        /// <returns>Um novo objeto Reserva</returns>
        public static Reserva CriarReserva(int id, Apartamento ap, Utilizador u, DateTime DataInicio, DateTime DataFim, int hospedes)
        {
            Reserva r = new Reserva(id, ap, u, DataInicio, DataFim, hospedes, true);
            return r;
        }

        #endregion

    }
}
