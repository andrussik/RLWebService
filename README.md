# RL web service

[For developers](#for-developers)
* [DAL](#dal)
* [BLL](#bll)
* [Domain](#domain)
* [Secrets](#secrets)
* [Rules](#rules)

***

## <a name="for-developers" /> For developers

### <a name="dal"/> DAL - *Data Access Layer*
* This layer should access data from external sources and return it, nothing else!
* DAL consists of repositories.
* Repositories have scoped lifetime.
* Repositories are registered in repository collection. Each external source has it's own repository collection.
* To create new repository:
    1. Create interface in Contracts directory.
    2. Create repository in App directory.
    3. Register new repository in repository collection.
* External sources:
    * Sierra API 
    * Riks API
    * Urram API
    * Database

### <a name="bll" /> BLL - *Business Logic Layer*    
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
  
### <a name="domain" /> Domain
* Our data model

### <a name="secrets" /> Secrets
* Initialize user secrets: dotnet user-secrets init
* Set a secret: dotnet user-secrets set "ApiKeys:ServiceApiKey" "12345"
* Remove a secret: dotnet user-secrets remove "ApiKeys:ServiceApiKey"
* List the secrets: dotnet user-secrets list

Access tokens are stored in IdentityServerClient and updated automatically with token handlers.

### <a name="rules" /> Rules
* Get rid of all the warnings before deploy!
* Feel free to add any rules ;)

### <a name="todo" /> TO-DO
* ~~Repository factory~~
* ~~Service factory~~
* ~~Injectable repository collection~~
* ~~Injectable storage collection~~

***