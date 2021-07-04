# docker-swarm-secrets-netcore3.1
Read Configuration from Docker swarm secrets folder(WINDOWS/UNIX)

Docker swarm by default allocate all secrets on:
  Windows : C:\ProgramData\Docker\secrets\
  UNIX : /run/secrets
  
 This library allow to read a configuration from custom secrets folder and default secrets folder
 
 Example:

  Read appsettings.json configuration from default Windows secrets folder
        
        '''csharp
             public Startup(IConfiguration configuration)
             {
                Configuration = configuration.UseSecret();
             }
         '''
