Run app local

Before run local app check Krestel config in appsettings.json
```
dotnet watch run
```

Run app with docker
```
docker build -t image-name -f dockerfile.api-gateway .
```

Ambient Environments
```
ENV ConnectionStrings__BlogDbConnection="server=localhost;port=3306;user=root;password=pass;database=default_db"
ENV JWT__ValidAudience="http://localhost:4200"
ENV JWT__ValidIssuer="http://localhost:5000"
ENV JWT__Secret="JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"
```

Config HTTPS, need create paste with certificates and config appsettings.json.