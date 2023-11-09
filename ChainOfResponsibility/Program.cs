var request = new Request();
var b = new B();

if (b.AuthenticateRequest(request))
    return;

if (b.AuthoiriseRequest(request))
    return;

if (b.ValidateRequest(request))
    return;

if (b.CachRequest(request))
    return;


public class Request { }
public class B
{

    public bool AuthenticateRequest(Request request)
    {
        // Stuff 
        // ...
        throw new NotImplementedException();
    }
    public bool ValidateRequest(Request request)
    {
        // Stuff 
        // ...
        throw new NotImplementedException();
    }
    public bool CachRequest(Request request)
    {
        // Stuff 
        // ...
        throw new NotImplementedException();
    }
    public bool AuthoiriseRequest(Request request)
    {
        // Stuff 
        // ...
        throw new NotImplementedException();
    }
}