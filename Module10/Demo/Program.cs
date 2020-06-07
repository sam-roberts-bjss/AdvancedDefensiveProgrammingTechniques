using System;
using System.IO;
using System.Net;

namespace Demo
{
    class Program
    {
        public static Either<Failed, Resource> Fetch(Uri address)
        {
            var request = WebRequest.Create(address);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new Left<Failed, Resource>(new NotFound());
                }

                if (response.StatusCode == HttpStatusCode.Redirect
                    || response.StatusCode == HttpStatusCode.TemporaryRedirect)
                {
                    Uri redirectUri = new Uri(response.Headers[HttpResponseHeader.Location]);
                    return new Left<Failed, Resource>(new Moved(redirectUri));
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new Left<Failed, Resource>(new Failed());
                }

                var dataStream = response.GetResponseStream();
                var data = new StreamReader(dataStream).ReadToEnd();
                return new Right<Failed, Resource>(new Resource(data));
            }
            catch (WebException webException) when (webException.Status == WebExceptionStatus.Timeout)
            {
                return new Left<Failed, Resource>(new Timeout());
            }
            catch (WebException)
            {
                return new Left<Failed, Resource>(new NetworkError());
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Uri address = new Uri("https://something.out.there");
                var result = Fetch(address);

                string report = result
                    .MapLeft(failure => $"Error fetching resource - {failure}")
                    .Reduce(resource => resource.Data);

                Console.WriteLine(report);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception}");
            }
        }
    }
}
