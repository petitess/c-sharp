public MyResponse HttpPatch(
        string url,
        string content,
        Dictionary<string, string> headers,
        string contentType = "application/json")
    {

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var request = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString(url));
        if (request == null)
            throw new ApplicationException(string.Format("Could not create the httprequest from the url:{0}", url));

        request.Method = "PATCH";
        foreach (var item in headers)
            request.Headers.Add(item.Key, item.Value);

        UTF8Encoding encoding = new UTF8Encoding();
        var byteArray = Encoding.ASCII.GetBytes(content);

        request.ContentLength = byteArray.Length;
        request.ContentType = contentType;

        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        try
        {
            var response = (HttpWebResponse)request.GetResponse();
            return new MyResponse(response);
        }
        catch (WebException ex)
        {
            HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;
            return new MyResponse(errorResponse);
        }
    }
