FROM microsoft/dotnet

WORKDIR /code

COPY . .

RUN dotnet restore

RUN dotnet build

ENTRYPOINT [ "dotnet", "run" ]