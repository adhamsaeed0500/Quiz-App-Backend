FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app1

# ننسخ فقط ملفات .csproj من مشاريع الـ Modules قبل restore

COPY src/Account/Account.API/Account.API.csproj Account.API/
COPY src/Account/Account.Application/Account.Application.csproj Account.Application/
COPY src/Account/Account.Domain/Account.Domain.csproj Account.Domain/
COPY src/Account/Acccount.Infrastructure/Acccount.Infrastructure.csproj Account.Infrastructure/

COPY src/Exam/Exam.API/Exam.API.csproj Exam.API/
COPY src/Exam/Exam.Application/Exam.Application.csproj Exam.Application/
COPY src/Exam/Exam.Domain/Exam.Domain.csproj Exam.Domain/
COPY src/Exam/Exam.Infrastructure/Exam.Infrastructure.csproj Exam.Infrastructure/

# بعدين نعمل restore على الـ solution
RUN dotnet restore Quiz_App.sln

COPY . .

RUN dotnet publish Quiz_App.sln -c Release -o /app1/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app2
COPY --from=build /app1/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Account.API.dll"]  # ← غيّر الاسم لو Entry Point غير Account.API