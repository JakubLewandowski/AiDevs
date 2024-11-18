namespace AIDevs.Helpers
{
    public class S01E04Helper
    {
        public async Task ResolveTask()
        {
            var ask = "Zadanie to doprowadzić robota do celu. Robot porusza się po macierzy składającej się z 4 wierszy i 6 kolum. Robot znajduje się na pozycji 1x4, a cel 6x4. Macierz: 1x1 czarny, 1x2 brązowy, 1x3 czarny, 1x4 czarny, 1x5 czarny, 1x6 czarny, 2x1 czarny, 2x2 czarny, 2x3 czarny, 2x4 brązowy, 2x5 czarny, 2x6 czarny, 3x1 czarny, 3x2 brązowe, 3x3 czarny, 3x4 brązowy, 3x5 czarny, 3x6 czarny, 4x1 robot, 4x2 brązowy, 4x3 czarny, 4x4 czarny, 4x5 czarny, 4x6 cel. Reguła poruszania: robot porusza się po czarnych polach macierzy, nie może stanąć na brązowym. Jeżeli robot przemieszcza się o wiersz wyżej (np. z 4x1 na 3x1) wyświetl \"UP\", jeżeli o wiersz niżej (np. z 3x1 na 4x1) to \"DOWN\". Jeżeli robot przemieszcza się do kolumny w prawo (np. z 2x1 na 2x2) wyświetl \"RIGHT\", jeżeli na kolumne w lewo (np. z 4x4 na 3x4) wyświetl \"LEFT\". Podsumowanie: musisz przejść z 4x1, 3x1, 2x1, 2x2, 2x3, 3x3, 4x3, 4x5, 4x6. Przykład: <RESULT> { \"steps\": \"UP, RIGHT, DOWN, LEFT\" } </RESULT>.";
            var ask2 = "Jeżeli jest 1 to wyświetl \"UP\", jeżeli 2 to \"DOWN\", jeżeli 3 \"RIGHT\", jeżeli 4 \"LEFT\", jeżeli 5 \"A\", jeżeli 6 \"B\". Ciąg to 1 1 2 2 4 3 " +
                " 4 3 6 5. Zamień to na odpowiednie słowa i wyświetl jako json w parametrze \"steps\". Wyświetl tylko json. W jsonie nie dodawaj spacji po przecinku. Przykład: { \"steps\": \"UP,RIGHT,DOWN,LEFT,A,B\" }.\"";
            var test = OpenAIHelper.Ask(ask2, "gpt-4o-mini");
        }
    }
}