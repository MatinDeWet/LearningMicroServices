------------------------------------------ Add-Migration ------------------------------------------ 
EntityFrameworkCore\Add-Migration xxx -Context CouponContext -Project Services.CouponAPI -StartupProject Services.CouponAPI -verbose -o Data/Migrations


------------------------------------------ Remove-Migration ------------------------------------------ 
EntityFrameworkCore\Remove-Migration -Context CouponContext -Project Services.CouponAPI -StartupProject Services.CouponAPI -verbose


------------------------------------------ Update-Database ------------------------------------------ 
EntityFrameworkCore\Update-Database -Context CouponContext -Project Services.CouponAPI -StartupProject Services.CouponAPI -verbose