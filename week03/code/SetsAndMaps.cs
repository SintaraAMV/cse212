using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public static class SetsAndMaps
{
   // Problem 1: Find Pairs
public static string[] FindPairs(string[] words)
{
    var seen = new HashSet<string>();
    var pairs = new List<string>();

    foreach (var word in words)
    {
        // El enunciado asume palabras de 2 caracteres; esto evita reventar si llega algo raro.
        if (string.IsNullOrEmpty(word) || word.Length != 2)
            continue;

        // Skip palindromes (same character words), ej: "aa"
        if (word[0] == word[1])
            continue;

        string reversed = $"{word[1]}{word[0]}";

        if (seen.Contains(reversed))
        {
            //  "ma & am", "fi & if" (el que “cierra” el par va primero)
            pairs.Add($"{word} & {reversed}");
        }
        else
        {
            seen.Add(word);
        }
    }

    return pairs.ToArray();
}


    // Problem 2: Degree Summary
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degreeCounts = new Dictionary<string, int>();

        try
        {
            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                var columns = line.Split(',');

                // Ensure we have at least 4 columns
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
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return degreeCounts;
    }

    // Problem 3: Anagrams
    public static bool IsAnagram(string word1, string word2)
    {
        // Clean strings: remove spaces and convert to lowercase
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        // Quick length check
        if (clean1.Length != clean2.Length)
            return false;

        // Count letters in first word
        var letterCounts = new Dictionary<char, int>();
        foreach (char c in clean1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        // Compare with second word
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

    // Problem 5: Earthquake JSON Data
    public static async Task<string[]> EarthquakeDailySummary()
    {
        using var client = new HttpClient();

        try
        {
            // USGS API for daily earthquakes
            string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            string json = await client.GetStringAsync(url);

            // Deserialize JSON
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            // Format output
            var results = new List<string>();
            foreach (var feature in data.Features)
            {
                string place = feature.Properties.Place;
                double mag = feature.Properties.Mag;
                results.Add($"{place} - Mag {mag:F2}");
            }

            return results.ToArray();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching earthquake data: {ex.Message}");
            return new string[0];
        }
    }
}