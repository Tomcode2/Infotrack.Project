using System.Web;

namespace Infotrack.FrequencyFinder.Web.EngineService
{
    /// <summary>
    /// Interface for search engine services.
    /// </summary>
    public interface IEngineService
    {
        string BaseUrl { get; }

        Uri GetEngineUri(string searchQuery);
        Task<string> ProcessSearchAsync(Uri url);

        List<int> GetSearchRank(string htmlDoc, Uri toFind);
    }

    public class GoogleEngineService : IEngineService
    {
        public string BaseUrl => "http://www.google.com/search?num=50&q=";

        public Uri GetEngineUri(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be null or empty", nameof(query));

            return new Uri(BaseUrl + Uri.EscapeDataString(HttpUtility.UrlEncode(query)));
        }

        public async Task<string> ProcessSearchAsync(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            using HttpClient httpClient = new();

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();
            string decodedHtml = HttpUtility.HtmlDecode(html);

            return decodedHtml;
        }

        public List<int> GetSearchRank(string htmlDoc, Uri toFind)
        {
            List<int> ranks = new List<int>();
            if (htmlDoc == null)
                throw new ArgumentNullException(nameof(htmlDoc));

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlDoc);

            var googleSearchNodes = document.DocumentNode.SelectNodes("//div[@class='egMi0 kCrYT']");

            if (googleSearchNodes == null)
                return ranks;

            int position = 0;
            foreach (var node in googleSearchNodes)
            {
                position++;
                string hrefValue = node.FirstChild.GetAttributeValue("href", string.Empty);
                if (hrefValue.Contains(toFind.AbsoluteUri, StringComparison.OrdinalIgnoreCase))
                {
                    ranks.Add(position);
                }
            }

            return ranks;
        }
    }

    public class BingEngineService : IEngineService
    {
        public string BaseUrl => "http://www.bing.com/search?q={0}&count=1000";

        public Uri GetEngineUri(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be null or empty", nameof(query));

            return new Uri(string.Format(BaseUrl, Uri.EscapeDataString(HttpUtility.UrlEncode(query))));
        }

        public async Task<string> ProcessSearchAsync(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            using HttpClient httpClient = new();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36");

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();
            string decodedHtml = HttpUtility.HtmlDecode(html);

            return decodedHtml;
        }

        public List<int> GetSearchRank(string htmlDoc, Uri toFind)
        {
            List<int> ranks = new List<int>();
            if (htmlDoc == null)
                throw new ArgumentNullException(nameof(htmlDoc));

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlDoc);

            var bingSearchNodes = document.DocumentNode.SelectNodes("//a[@class='tilk']");

            if (bingSearchNodes == null)
                return ranks;

            if (bingSearchNodes != null)
            {
                int position = 0;
                foreach (var node in bingSearchNodes)
                {
                    position++;
                    string hrefValue = node.GetAttributeValue("href", string.Empty);
                    if (hrefValue.Contains(toFind.AbsoluteUri, StringComparison.OrdinalIgnoreCase))
                    {
                        ranks.Add(position);
                    }
                }
            }

            return ranks;
        }
    }

    public class YahooEngineService : IEngineService
    {
        public string BaseUrl => "http://search.yahoo.com/search?p=";

        public Uri GetEngineUri(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be null or empty", nameof(query));

            return new Uri(BaseUrl + Uri.EscapeDataString(HttpUtility.UrlEncode(query)));
        }
        public async Task<string> ProcessSearchAsync(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            using HttpClient httpClient = new();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36");

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();
            string decodedHtml = HttpUtility.HtmlDecode(html);

            return decodedHtml;
        }

        public List<int> GetSearchRank(string htmlDoc, Uri toFind)
        {
            List<int> ranks = new List<int>();
            if (htmlDoc == null)
                throw new ArgumentNullException(nameof(htmlDoc));

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlDoc);

            var nodes = document.DocumentNode.SelectNodes("//a[@cite and @href]");


            var yahooSearchNodes = document.DocumentNode.SelectNodes("//a[@cite and @href]");

            if (yahooSearchNodes == null)
                return ranks;

            if (yahooSearchNodes != null)
            {
                int position = 0;
                foreach (var node in yahooSearchNodes)
                {
                    position++;
                    string hrefValue = node.GetAttributeValue("href", string.Empty);
                    if (hrefValue.Contains(toFind.AbsoluteUri, StringComparison.OrdinalIgnoreCase))
                    {
                        ranks.Add(position);
                    }
                }
            }

            return ranks;
        }
    }
}
