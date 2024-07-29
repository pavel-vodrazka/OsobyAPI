# OsobyApi

Jednoduché webové API v ASP.NET Framework 4.8 podle zadání úlohy pro výběrové řízení.

Jako datové úložiště využívá MSSQLLocalDB a pracuje s Entity Frameworkem (přístup code first).

Spustí se z Visual Studia s nebo bez debugování. Po spuštění se otevře v prohlížeči
stránka s dokumentací ve Swaggeru. API je dostupné na portu 44309, endpointy jsou
GET /api/osoby/{id} a POST /api/osoby. Loguje (Serilog) do složky logs ve složce projektu.

Testovací projekt v xUnit je v zárodku, zde zatím nemám dostatek zkušeností s mockingem
u tohoto typu aplikací a dostatek času.