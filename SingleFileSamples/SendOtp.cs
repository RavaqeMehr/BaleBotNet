#:property PublishAot=false
#:package BaleBotNet@3.0.0

using BaleBotNet.Safir;

SafirOtpClient safirOtp = new("usename", "password");
await safirOtp.InitAuth();
await safirOtp.SendOtp("989123456789", 123456);