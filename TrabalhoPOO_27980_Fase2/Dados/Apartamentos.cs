/// \file Apartamentos.cs
/// \brief Classe para gerir apartamentos.
/// \details Esta classe permite criar, atualizar e remover informações sobre apartamentos.
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
    /// \class Apartamentos
    /// \brief Classe para gerir operações relacionadas a apartamentos.
    public class Apartamentos
    {
        #region Attributes

        /// \brief Lista de Apartamentos.

        private static List<Apartamento> ListaApartamentos = new List<Apartamento>();

        #endregion

        #region Methods


        /// <summary>
        /// \brief Cria um novo apartamento e adiciona-o a lista.
        /// </summary>
        /// <param name="id">Identificador unico do apartamento.</param>
        /// <param name="nome">Nome do apartamento.</param>
        /// <param name="endereco">Endereco do apartamento.</param>
        /// <param name="valorDiaria">Valor diario do apartamento.</param>
        /// <param name="c">Capacidade do apartamento.</param>
        /// <param name="disponivel">Indica se o apartamento esta disponivel.</param>
        /// <param name="possuiWifi">Indica se o apartamento possui Wi-Fi.</param>
        /// <returns>Retorna true se o apartamento foi criado com sucesso.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o ID seja duplicado</exception>
        public static bool CriarApartamento(int id, string nome, string endereco, double valorDiaria, int c, bool disponivel, bool possuiWifi)
        {
            if (BuscarApartamentoPorId(id) != null)
            {
                throw new ExcecaoApartamento(1);
            }

            if (ValidarApartamentos.ValidarApartamento(id, nome, endereco, valorDiaria, c) == false)
            {
                return false;
            }

            Apartamento ap = Apartamento.CriarApartamento(id, nome, endereco, valorDiaria, c, disponivel, possuiWifi);
            AdicionarApartamento(ap);

            return true;
        }

        /// <summary>
        /// \brief Busca um apartamento pelo ID.
        /// </summary>
        /// <param name="id">ID do apartamento.</param>
        /// <returns>O apartamento caso encontre ou null se não encontrar.</returns>
        public static Apartamento BuscarApartamentoPorId(int id)
        {
            foreach (Apartamento ap in ListaApartamentos)
            {
                if (ap.Id == id) return ap;
            }
            return null;

        }

        /// <summary>
        /// \brief Adiciona um apartamento a lista de apartamentos.
        /// </summary>
        /// <param name="ap">Objeto do tipo Apartamento.</param>
        /// <returns>Retorna true se o apartamento foi adicionado com sucesso.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o objeto seja nulo.</exception>
        public static bool AdicionarApartamento(Apartamento ap)
        {
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }

            ListaApartamentos.Add(ap);
            return true;
        }

        /// <summary>
        /// \brief Atualiza os dados de um apartamento.
        /// </summary>
        /// <param name="id">ID apartamento a ser atualizado.</param>
        /// <param name="idNovo">idNovo Novo id do apartamento.</param>
        /// <param name="nome">Novo nome do apartamento.</param>
        /// <param name="endereco">Novo endereco do apartamento.</param>
        /// <param name="valorDiaria">Novo valor diario.</param>
        /// <param name="c">Nova capacidade.</param>
        /// <param name="disponivel">Atualiza a disponibilidade do apartamento.</param>
        /// <param name="wifi">Atualiza se o apartamento possui Wi-Fi.</param>
        /// <returns>Retorna true se os dados foram atualizados com sucesso, false se nao.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento nao seja encontrado ou o ID seja duplicado.</exception>
        public static bool AtualizarApartamento(int id, int idNovo, string nome, string endereco, double valorDiaria, int c, bool disponivel, bool wifi)
        {
            Apartamento ap = BuscarApartamentoPorId(id);
            Apartamento ap2 = BuscarApartamentoPorId(idNovo);

            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }
            if (ap2 != null)
            {
                throw new ExcecaoApartamento(1);
            }

            if (ValidarApartamentos.ValidarApartamento(idNovo, nome, endereco, valorDiaria, c) == false)
            {
                return false;
            }

            ap.Id = idNovo;
            ap.Nome = nome;
            ap.Endereco = endereco;
            ap.ValorDiaria = valorDiaria;
            ap.Capacidade = c;
            ap.Disponivel = disponivel;
            ap.PossuiWifi = wifi;

            return true;
        }

        /// <summary>
        /// \brief Remove um apartamento pelo ID.
        /// </summary>
        /// <param name="id">Id unico do apartamento.</param>
        /// <returns>Retorna true se o apartamento foi removido com sucesso.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento nao seja encontrado.</exception>
        public static bool RemoverApartamento(int id)
        {
            Apartamento ap = BuscarApartamentoPorId(id);

            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }

            ListaApartamentos.Remove(BuscarApartamentoPorId(id));
            return true;
        }

        /// <summary>
        /// \brief Atualiza o status de disponibilidade de um apartamento.
        /// </summary>
        /// <param name="ap">Objeto do tipo Apartamento</param>
        /// <returns>Retorna true se o status foi atualizado com sucesso.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento seja nulo.</exception>
        public static bool AtualizarStatusApartamento(Apartamento ap)
        {
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }
            if (ap.Disponivel == true)
            {
                ap.Disponivel = false;
            }
            else
            {
                ap.Disponivel = true;
            }
            return true;
        }

        /// <summary>
        /// \brief Verifica o status de disponibilidade de um apartamento.
        /// </summary>
        /// <param name="ap">Objeto do tipo Apartamento.</param>
        /// <returns>Retorna true se o apartamento estiver disponível, caso contrário false.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o apartamento seja nulo.</exception>
        public static bool VerificarStatusApartamento(Apartamento ap)
        {
            if (ap == null)
            {
                throw new ExcecaoApartamento(2);
            }
            else
            {
                return ap.Disponivel;
            }
        }

        #region Ficheiros

        /// <summary>
        /// \brief Salva a lista de apartamentos em um ficheiro binário.
        /// </summary>
        /// <param name="ficheiro">Nome do ficheiro onde os dados serão salvos.</param>
        /// <returns>Retorna true se os dados foram salvos com sucesso.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o nome do ficheiro seja nulo ou vazio.</exception>
        public static bool GuardarApartamentosFicheiro(string ficheiro)
        {
            if (ficheiro == "" || ficheiro == null)
            {
                throw new ExcecaoApartamento(6);
            }

            Stream stream = File.Open(ficheiro, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, ListaApartamentos);
            stream.Close();

            return true;
        }

        /// <summary>
        /// \brief Lê a lista de apartamentos de um ficheiro binário.
        /// </summary>
        /// <param name="ficheiro">Nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>Retorna true se os dados foram lidos com sucesso.</returns>
        /// <exception cref="ExcecaoApartamento">Caso o nome do ficheiro seja nulo ou vazio.</exception>
        public static bool LerApartamentosFicheiro(string ficheiro)
        {
            if (ficheiro == "" || ficheiro == null)
            {
                throw new ExcecaoApartamento(6);
            }

            Stream stream = File.Open(ficheiro, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            ListaApartamentos = (List<Apartamento>)bin.Deserialize(stream);
            stream.Close();

            return true;

        }


        #endregion

        #endregion

    }
}
