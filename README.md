# RL web service

## For developers

### DAL - <em>Data Access Layer</em>
- This layer should access data from external sources and return it, nothing else!
- DAL consists of repositories.
- External sources:
    - Sierra API
    - Riks API
    - Urram API
    - Database
    
### BLL - <em>Business Logic Layer</em>
- This layer should do all the mandatory calculations.
- BLL consists of BLL apps and services.
- BLL apps contain static methods that are used across services to make necessary calculations.
- Services make necessary calculations and provide output for:
  - controllers -> client (on data request)
  - repositories -> external sources (on data post).
  
### Domain
- Our data model

### Secrets
- Initialize user secrets: dotnet user-secrets init
- Set a secret: dotnet user-secrets set "ApiKeys:ServiceApiKey" "12345"
- Remove a secret: dotnet user-secrets remove "ApiKeys:ServiceApiKey"
- List the secrets: dotnet user-secrets list

Access tokens are stored in IdentityServerClient and updated automatically with token handlers.

### Rules
- Get rid of all the warnings before deploy!
- Feel free to add any rules ;)

### TODO
- Repository factory
- Service factory
- Injectable storage of repositories
- Injectable storage of services

<hr>