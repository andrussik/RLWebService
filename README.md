# RL web service

[For developers](#for-developers)
* [DAL](#dal)
* [BLL](#bll)
* [Domain](#domain)
* [Secrets](#secrets)
* [Rules](#rules)

<hr>

<h2 name="for-developers">For developers</h2>

<h3 name="dal">DAL - <em>Data Access Layer</em></h3>
* This layer should access data from external sources and return it, nothing else!
* DAL consists of repositories.
* Repositories have scoped lifetime.
* Repositories are registered in repository collection. Each external source has it's own repository collection.
* To create new repository:
     1. Create interface in Contracts directory.
     2. Create repository in App directory.
     3. Register new repository in repository collection.
* External sources:
    - Sierra API
    - Riks API
    - Urram API
    - Database

<h3 name="bll">BLL - <em>Business Logic Layer</em></h3>    
* This layer should do all the mandatory calculations.
* BLL consists of BL classes and services.
* BL classes are static and contain methods that are used across services to make necessary calculations.
* Services make necessary calculations and provide output for:
    * controllers -> client (on data request)
    * repositories -> external sources (on data post).

* Services have scoped lifetime.
* Services are registered in service collection.
* To create new service:
    1. Create interface in Contracts directory.
    2. Create repository in App directory.
    3. Register new service in service collection.
  
<h3 name="domain">Domain</h3>
* Our data model

<h3 name="secrets">Secrets</h3>
* Initialize user secrets: dotnet user-secrets init
* Set a secret: dotnet user-secrets set "ApiKeys:ServiceApiKey" "12345"
* Remove a secret: dotnet user-secrets remove "ApiKeys:ServiceApiKey"
* List the secrets: dotnet user-secrets list

Access tokens are stored in IdentityServerClient and updated automatically with token handlers.

<h3 name="rules">Rules</h3>
* Get rid of all the warnings before deploy!
* Feel free to add any rules ;)

<h3 name="todo">TO-DO</h3>
* ~~Repository factory~~
* ~~Service factory~~
* ~~Injectable repository collection~~
* ~~Injectable storage collection~~

<hr>