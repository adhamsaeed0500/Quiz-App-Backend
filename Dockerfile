FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# ننسخ فقط ملفات .csproj من مشاريع الـ Modules قبل restore
COPY Quiz_App.sln .

COPY Account/Account.API/Account.API.csproj Account.API/
COPY Account/Account.Application/Account.Application.csproj Account.Application/
COPY Account/Account.Domain/Account.Domain.csproj Account.Domain/
COPY Account/Account.Infrastructure/Account.Infrastructure.csproj Account.Infrastructure/

COPY Exam/Exam.API/Exam.API.csproj Exam.API/
COPY Exam/Exam.Application/Exam.Application.csproj Exam.Application/
COPY Exam/Exam.Domain/Exam.Domain.csproj Exam.Domain/
COPY Exam/Exam.Infrastructure/Exam.Infrastructure.csproj Exam.Domain/

# بعدين نعمل restore على الـ solution
RUN dotnet restore Quiz_App.sln

COPY . .

RUN dotnet publish Quiz_App.sln -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Account.API.dll"]  # ← غيّر الاسم لو Entry Point غير Account.API