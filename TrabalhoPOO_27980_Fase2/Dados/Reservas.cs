/// \file Reservas.cs
/// \brief Classe estatica para gerir reservas.
/// \details Esta classe permite criar, atualizar e remover informações sobre reservas.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using ObjetosDeNegocio;
using Excecoes;
using Validacoes;

namespace Dados
{
    /// <summary>
    /// \class Reservas
    /// \brief Classe para gerir operações relacionadas a reservas. 
    /// </summary>
    public class Reservas
    {
        #region Attributes

        /// \brief Lista de Reservas.
        private static List<Reserva> ListaReservas = new List<Reserva>();

        #endregion

        #region Methods


        /// <summary>
        /// \brief Cria uma nova reserva.
        /// </summary>
        /// <param name="id">ID da reserva</param>
        /// <param name="idApartamento">ID do apartamento</param>
        /// <param name="idUtilizador">ID do utilizador</param>
        /// <param name="DataInicio">Data do início da reserva</param>
        /// <param name="DataFim">Data final da reserva</param>
        /// <param name="hospedes">Número total de hóspedes</param>
        /// <returns>True se a reserva for criada com sucesso, caso contrário, false</returns>
        /// <exception cref="ExcecaoUtilizadores">Caso o utilizador não for encontrado</exception>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento não for encontrado ou não estiver disponível</exception>
        /// <exception cref="ExcecaoReservas">Caso a reserva não for valida(hospedes) ou já existir</exception>
        public static bool CriarReserva(int id, int idApartamento, int idUtilizador, DateTime DataInicio, DateTime DataFim, int hospedes)
        {
            Apartamento ap = Apartamentos.BuscarApartamentoPorId(idApartamento);
            Utilizador u = Utilizadores.BuscarUserPorId(idUtilizador);

            //Verificar se utilizador existe
            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }
            //Verificar se apartamento existe
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }
            //Validar atributos da reserva
            if (ValidarReservas.ValidarReserva(id, DataInicio, DataFim, hospedes) == false)
            {
                return false;
            }
            //Verificar se apartamento nao esta ocupado
            if (ap.Disponivel == false)
            {
                throw new ExcecaoApartamento(3);
            }
            //Verificar capacidade do apartamento
            if (ap.Capacidade < hospedes)
            {
                throw new ExcecaoReservas(4);
            }
            //Verificar se a reserva com o ID dado existe
            if (BuscarReservaPorId(id) != null)
            {
                throw new ExcecaoReservas(1);
            }

            //Criar Reserva e Adiciona-la a lista
            Reserva r = Reserva.CriarReserva(id, ap, u, DataInicio, DataFim, hospedes);

            Apartamentos.AtualizarStatusApartamento(ap);

            AdicionarReserva(r);
            return true;
        }

        /// <summary>
        /// \brief Adiciona uma reserva a lista de reservas.
        /// </summary>
        /// <param name="r">Objeto do tipo reserva</param>
        /// <returns>True se a reserva for adicionada com sucesso</returns>
        /// <exception cref="ExcecaoReservas">Se a reserva for nula</exception>
        public static bool AdicionarReserva(Reserva r)
        {
            if (r != null)
            {
                ListaReservas.Add(r);
                return true;
            }
            throw new ExcecaoReservas(2);

        }

        /// <summary>
        /// \brief Busca uma reserva pelo ID.
        /// </summary>
        /// <param name="id">ID unico da reserva.</param>
        /// <returns>A reserva correspondente ou null se nao encontrada.</returns>
        public static Reserva BuscarReservaPorId(int id)
        {
            foreach (Reserva reserva in ListaReservas)
            {
                if (reserva.Id == id) return reserva;
            }
            return null;
        }

        /// <summary>
        /// \brief Atualiza os dados de uma reserva.
        /// </summary>
        /// <param name="id">ID da reserva a ser atualizada</param>
        /// <param name="idNovo">Novo ID da reserva</param>
        /// <param name="idApartamento">ID do apartamento atual</param>
        /// <param name="idApNovo">Novo ID do apartamento</param>
        /// <param name="idUNovo">Novo ID do utilizador</param>
        /// <param name="dataInicio">Nova data de início da reserva</param>
        /// <param name="dataFim">Nova data final da reserva</param>
        /// <param name="hospedes">Novo número total de hóspedes</param>
        /// <returns>True se a reserva for atualizada com sucesso, caso contrário, false</returns>
        /// <exception cref="ExcecaoReservas">Caso a reserva não for encontrada ou já existir</exception>
        /// <exception cref="ExcecaoUtilizadores">Caso o utilizador não for encontrado</exception>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento não for encontrado ou não estiver disponível</exception>
        public static bool AtualizarReserva(int id, int idNovo, int idApartamento, int idApNovo, int idUNovo, DateTime dataInicio, DateTime dataFim, int hospedes)
        {
            Reserva r = BuscarReservaPorId(id);
            Apartamento ap = Apartamentos.BuscarApartamentoPorId(idApNovo);
            Utilizador u = Utilizadores.BuscarUserPorId(idUNovo);

            //Verificar se a reserva existe
            if (r == null)
            {
                throw new ExcecaoReservas(2);
            }
            //Verificar se a reserva com o id novo existe
            if (BuscarReservaPorId(idNovo) != null)
            {
                throw new ExcecaoReservas(1);
            }
            //Verificar se o utilizador novo existe
            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }
            //Verificar se o apartamento novo existe
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }
            //Verificar atributos da reserva
            if (ValidarReservas.ValidarReserva(idNovo, dataInicio, dataFim, hospedes) == false)
            {
                return false;
            }
            //Verifica nova capacidade
            if (ap.Capacidade < hospedes)
            {
                throw new ExcecaoReservas(4);
            }
            //Verificar se o apartamento novo esta disponivel
            if (Apartamentos.VerificarStatusApartamento(ap) == false)
            {
                throw new ExcecaoReservas(6);
            }

            r.Id = idNovo;
            r.Ap = ap;
            r.U = u;
            r.DataInicio = dataInicio;
            r.DataFim = dataFim;
            r.Hospedes = hospedes;

            return true;

        }

        /// <summary>
        /// \brief Remove uma reserva pelo ID e ID do apartamento da reserva.
        /// </summary>
        /// <param name="id">ID da reserva</param>
        /// <param name="idApartamento">ID do apartamento</param>
        /// <returns>True se a reserva for removida com sucesso</returns>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento não for encontrado</exception>
        /// <exception cref="ExcecaoReservas">Caso se a reserva não for encontrada</exception>
        public static bool RemoverReserva(int id, int idApartamento)
        {
            Reserva r = BuscarReservaPorId(id);
            Apartamento ap = Apartamentos.BuscarApartamentoPorId(idApartamento);

            //Verificar se o apartamento existe
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }
            //Verificar se a reserva existe
            if (r != null)
            {
                CancelarReserva(id, idApartamento); //Cancela a reserva antes de remover da lista
                ListaReservas.Remove(r);
                return true;
            }
            throw new ExcecaoReservas(2);
        }


        /// <summary>
        /// \brief Cancela uma reserva pelo seu ID e ID do apartamento associado.
        /// </summary>
        /// <param name="id">ID da reserva</param>
        /// <param name="idApartamento">ID do apartamento</param>
        /// <returns>True se a reserva for cancelada com sucesso</returns>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento não for encontrado</exception>
        /// <exception cref="ExcecaoReservas">Caso a reserva não for encontrada</exception>
        public static bool CancelarReserva(int id, int idApartamento)
        {
            Reserva r = BuscarReservaPorId(id);
            Apartamento ap = Apartamentos.BuscarApartamentoPorId(idApartamento);

            //Verificar se o apartamento existe
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }

            //Verificar se a reserva existe
            if (r != null)
            {
                r.Status = false;
                r.Id = -100;
                //Atualiza a disponibilidade do apartamento para disponivel
                Apartamentos.AtualizarStatusApartamento(ap);

                return true;
            }
            throw new ExcecaoReservas(2);
        }

        #region Ficheiros

        /// <summary>
        /// \brief Salva a lista de reservas num ficheiro binário.
        /// </summary>
        /// <param name="ficheiro">Nome do ficheiro</param>
        /// <returns>True se a lista for salva com sucesso</returns>
        /// <exception cref="ExcecaoReservas">Caso nome do ficheiro seja nulo ou esteja vazio</exception>
        public static bool GuardarReservasFicheiro(string ficheiro)
        {
            //Verificar se a string e nula ou esta vazia
            if (ficheiro == "" || ficheiro == null)
            {
                throw new ExcecaoReservas(5);
            }

            Stream stream = File.Open(ficheiro, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, ListaReservas);
            stream.Close();

            return true;
        }

        /// <summary>
        /// \brief Le a lista de reservas num ficheiro binário.
        /// </summary>
        /// <param name="ficheiro">Nome do ficheiro</param>
        /// <returns>True se a lista for lida com sucesso</returns>
        /// <exception cref="ExcecaoReservas">Caso nome do ficheiro seja nulo ou esteja vazio</exception>
        public static bool LerReservasFicheiro(string ficheiro)
        {
            //Verificar se a string e nula ou esta vazia
            if (ficheiro == "" || ficheiro == null)
            {
                throw new ExcecaoReservas(5);
            }

            Stream stream = File.Open(ficheiro, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            ListaReservas = (List<Reserva>)bin.Deserialize(stream);
            stream.Close();

            return true;
        }

        #endregion

        #endregion

    }
}
