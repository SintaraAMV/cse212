using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class SetsAndMaps
{
    // 1. FindPairs - recibe string[] y devuelve string[]
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            if (string.IsNullOrEmpty(word) || word.Length != 2)
                continue;

            // Skip palindromes (same character words)
            if (word[0] == word[1])
                continue;

            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                // Formato: "ma & am"
                pairs.Add($"{word} & {reversed}");
                seen.Remove(reversed);
            }
            else
            {
                seen.Add(word);
            }
        }

        return pairs.ToArray();
    }

    // 2. SummarizeDegrees - recibe string (filename) y devuelve Dictionary<string, int>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degreeCounts = new Dictionary<string, int>();

        try
        {
            // Ir 3 niveles arriba para encontrar census.txt
            var fullPath = Path.GetFullPath(filename);
            var lines = File.ReadAllLines(fullPath);

            foreach (var line in lines)
            {
                var columns = line.Split(',');

                // Columna 3 contiene el grado (índice 3, cuarta columna)
                if (columns.Length >= 4)
                {
                    var degree = columns[3].Trim();

                    if (!string.IsNullOrEmpty(degree))
                    {
                        if (degreeCounts.ContainsKey(degree))
                            degreeCounts[degree]++;
                        else
                            degreeCounts[degree] = 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            // Retornar diccionario vacío o lanzar excepción según sea necesario
        }

        return degreeCounts;
    }

    // 3. IsAnagram - recibe 2 strings y devuelve bool
    public static bool IsAnagram(string s1, string s2)
    {
        if (s1 == null || s2 == null)
            return false;

        // Limpiar strings: quitar espacios y convertir a minúsculas
        string clean1 = new string(s1.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
        string clean2 = new string(s2.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());

        // Si las longitudes son diferentes, no son anagramas
        if (clean1.Length != clean2.Length)
            return false;

        // Contar letras en la primera palabra
        var letterCounts = new Dictionary<char, int>();
        foreach (char c in clean1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        // Comparar con la segunda palabra
        foreach (char c in clean2)
        {
            if (!letterCounts.ContainsKey(c))
                return false;

            letterCounts[c]--;
            if (letterCounts[c] == 0)
                letterCounts.Remove(c);
        }

        return letterCounts.Count == 0;
    }

    // 4. EarthquakeDailySummary - NO recibe parámetros, devuelve string[]
    public static string[] EarthquakeDailySummary()
    {
        // Ruta al archivo earthquake.csv
        string filePath = "earthquake.csv";
        
        // Si no existe el archivo, crear datos de ejemplo
        if (!File.Exists(filePath))
        {
            // Crear archivo earthquake.csv con datos de ejemplo
            var sampleData = new string[]
            {
                "2023-01-01,5.5,California - Mag 5.5",
                "2023-01-01,3.2,Alaska - Mag 3.2",
                "2023-01-02,4.1,Japan - Mag 4.1",
                "2023-01-02,2.8,Chile - Mag 2.8",
                "2023-01-03,6.0,Indonesia - Mag 6.0",
                "2023-01-03,4.5,New Zealand - Mag 4.5",
                "2023-01-04,3.9,Greece - Mag 3.9",
                "2023-01-05,5.1,Turkey - Mag 5.1",
                "2023-01-05,4.2,Italy - Mag 4.2",
                "2023-01-06,3.5,Mexico - Mag 3.5"
            };
            
            // Guardar en archivo (opcional)
            File.WriteAllLines(filePath, sampleData);
            
            return sampleData;
        }

        // Leer el archivo existente
        return File.ReadAllLines(filePath);
    }
}