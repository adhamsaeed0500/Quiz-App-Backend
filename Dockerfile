FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. نسخ ملف solution
COPY Quiz_App.sln .

# 2. نسخ جميع ملفات المشاريع مع المسارات الصحيحة
# Account Projects
COPY src/Account/Account.API/Account.API.csproj src/Account/Account.API/
COPY src/Account/Account.Application/Account.Application.csproj src/Account/Account.Application/
COPY src/Account/Account.Domain/Account.Domain.csproj src/Account/Account.Domain/
COPY src/Account/Acccount.Infrastructure/Acccount.Infrastructure.csproj src/Account/Acccount.Infrastructure/

# Exam Projects
COPY src/Exam/Exam.API/Exam.API.csproj src/Exam/Exam.API/
COPY src/Exam/Exam.Application/Exam.Application.csproj src/Exam/Exam.Application/
COPY src/Exam/Exam.Domain/Exam.Domain.csproj src/Exam/Exam.Domain/
COPY src/Exam/Exam.Infrastructure/Exam.Infrastructure.csproj src/Exam/Exam.Infrastructure/

COPY src/Shared/Return.csproj src/Shared/  

# Quiz System
COPY Quiz_System/Quiz_App.csproj Quiz_System/

# 3. استعادة الحزم مع تفاصيل الخطأ
RUN dotnet restore Quiz_App.sln --verbosity detailed

# 4. نسخ باقي الملفات
COPY . .

# 5. البناء والنشر
RUN dotnet publish Quiz_System/Quiz_App.csproj -c Release -o /app/out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Quiz_App.dll"]