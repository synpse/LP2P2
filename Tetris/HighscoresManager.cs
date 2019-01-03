using System;
using System.Collections.Generic;
using System.IO;

namespace Tetris
{
    /// <summary>
    /// Creates HighscoreManager Class
    /// </summary>
    class HighscoresManager
    {
        private List<Tuple<string, float, string>> highscores;

        private string filename = "";

        /// <summary>
        /// Creates the HighscoreManger Constructor where it saves or creates
        /// a new file to store the scores
        /// </summary>
        /// <param name="filename"></param>
        public HighscoresManager(string filename = "HighScores.txt")
        {
            ///Inicializa o ficheiro com o nome do ficheiro fornecido no 
            ///constructor.
            this.filename = filename;

            ///Se o ficheiro escolhido não existir, cria uma nova lista que contêm
            ///o nome e a pontuação do jogador.
            if (!File.Exists(filename))
            {
                highscores = new List<Tuple<string, float, string>>(10);
            }

            ///Se o ficherio existe irá efectuar o seguinte código.
            else
            {

                ///inicializa a lista.
                highscores = new List<Tuple<string, float, string>>(10);

                ///Lê todas as linhas do ficheiro obtido.
                string[] text = File.ReadAllLines(filename);

                ///Pecorre todas as linhas do ficheiro.
                for (int i = 1; i < text.Length; i++)
                {

                    ///Separa as linhas de acordo com o formato indicado.
                    string[] subStrings = text[i].Split(':');

                    ///Se o formato pedido estiver incorrecto ou a substring não
                    ///for possível converter em float.
                    if (subStrings.Length != 3 ||
                        !Single.TryParse(subStrings[1], out float score))
                    {

                        ///Envia uma mensagem de erro ao utilizador.
                        throw new InvalidOperationException($"The format of " +
                            $"the file '{filename}' is not correct.");
                    }

                    ///Salva o nome da primeira substring.
                    string name = subStrings[0];
                    string difficulty = subStrings[2];

                    ///Adiciona a nova melhor pontuação a lista
                    highscores.Add(new Tuple<string, float, string>(name, score, difficulty));
                }

                ///Ordena a lista de forma descendente. 
                SortList();
            }
        }

        /// <summary>
        /// Creates the AddScore Method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="difficulty"></param>
        public void AddScore(string name, float score, string difficulty)
        {
            ///Cria e instância um novo objecto que guarda a nova pontuação.
            Tuple<string, float, string> newScore = new Tuple<string, float, string>
                (name, score, difficulty);

            /// Adiciona o nova melhor pontuação a lista.
            highscores.Add(newScore);

            ///Ordena a lista de forma descendente.
            SortList();

            ///Verifica se a lista possui mais que dez elementos
            if (highscores.Count > 10)
            {
                ///remove o ultimo elemento pois deixou de pertencer ao top10-
                highscores.RemoveAt(highscores.Count - 1);
            }
        }

        /// <summary>
        /// Creates the Save Method
        /// </summary>
        public void Save()
        {
            ///Cria uma variável para guardar o texto da lista
            string text = "Name:Score\n";

            ///Para cada elemento na lista
            foreach (Tuple<string, float, string> highscore in highscores)
            {
                ///Adiciona o nome e pontuação
                text += $"{highscore.Item1}:{highscore.Item2}:{highscore.Item3}\n";
            }

            ///Escreve tudo o que obteve com o foreach no ficheiro indicado .txt.
            File.WriteAllText(filename, text);
        }

        /// <summary>
        /// Creates the GetScore method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tuple<string, float, string>> GetScores()
        {
            ///Pecorre todas as pontuações na lista.
            foreach (Tuple<string, float, string> highscore in highscores)
            {
                ///Retorna todas as pontuações que encontrar na lista.
                yield return highscore;
            }
        }

        /// <summary>
        /// Creates the SortList Method
        /// </summary>
        private void SortList()
        {
            ///Ordena os elementos da lista de forma descendente
            for (int i = 0; i <= highscores.Count - 1; i++)
            {
                for (int j = 0; j < highscores.Count - 1; j++)
                {
                    ///Utiliza o algoritmo Bubble Sort para ordenar a lista.
                    if (highscores[j].Item2 < highscores[i].Item2)
                    {
                        Tuple<string, float, string> temp = highscores[i];
                        highscores[i] = highscores[j];
                        highscores[j] = temp;
                    }
                }
            }
        }
    }
}
