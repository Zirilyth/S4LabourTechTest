# S4LabourTechTest API

# Development server

To start a local development server, run:

```bash
dotnet run
```

To build the project, run:

```bash
dotnet build
```

#Tech Test Notes:

# Overview

This is a simple API just for proxying a 3rd party endpoint and storing notes, which I hold in a singleton service in a
dictionary
Ive split the logic into a controller for the endpoints and two services; The employee service, and the notes service,
which just handles the notes for an employee

The dictionary is formatted as [Key:EmployeeID,Value:List<Notes>]. The system doesnt recognise the employees themselves which
is not ideal for a working system, but this is
due to the endpoint being random, which would not be the case in a real system.

## Performance

My first thought for performance is to cache the request from the randomUser endpoint reducing the number of requests
that we need to do, which should make calling the endpoint for employees quicker.

We could also set up a pagination system
 where we can grab chunks of data as we need them, instead of it all at once. This would allow the service to scale better 
or a significantly larger dataset

## Notes for Improvement

I would aim to implement a nicer validation system (thinking fluent validation etc).

Using a repository pattern would be overkill for a tech test but would be good for maintainability and
changing how data is stored if we needed to in the future.

A logging system (Ideally a structured one such as Serilog so we can
have better observability, which is again overkill for a tech test)



