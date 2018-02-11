FROM microsoft/aspnetcore:2.0

WORKDIR /app  
COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet CinemaOL.Core.dll

# Setp to deploy on heroku
# 1) dotnet publish 
# 2) Paste the /Data folder to publish folder
# 3) Navigate to publish folder
# 4) run heroku container:push web
