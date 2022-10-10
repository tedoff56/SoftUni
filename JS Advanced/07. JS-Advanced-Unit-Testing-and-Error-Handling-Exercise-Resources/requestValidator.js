function validate(httpRequest){ 
    
    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if(!validMethods.includes(httpRequest.method)){
        throw new Error('Invalid request header: Invalid Method');
    }

    if(!(httpRequest.uri && (/^[\w.]+$/.test(httpRequest.uri) || httpRequest.uri === "*"))){
        throw new Error('Invalid request header: Invalid URI');
    }
    if(!validVersions.includes(httpRequest.version)){
        throw new Error('Invalid request header: Invalid Version');
    }
    if(!(httpRequest.hasOwnProperty("message") && (/^[^<>\\&'"]*$/.test(httpRequest.message) || httpRequest.message == ""))){
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpRequest;
}

console.log(validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  }));

  console.log(validate({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
  }));