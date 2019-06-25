# .NET Demo

## WebSocket

包含HTML文档，演示HTML WebSocket客户端与.NET后台通讯

## SocketDemo


- Socket简介


	通过TCP/IP与仪器或设备通讯，在C#语言中，我们通常采用Socket。本项目是一个简单的Socket建立服务监听与Socket作为客户端请求的一个示例。

- 项目结构

	- 客户端项目 SocketClient

		主要负责作为Socket客户端发起连接请求，并发送数据

	- 服务端项目 SocketDemo

		主要负责作为Socket服务端，监听端口并接收连接请求，并返回应答数据

- 项目演示

	- 先运行SocketDemo进行服务监听
	- 运行SocketClient进行模拟连接，并发送接收数据。

## QRCode DEMO


- QR二维码

	二维码的一种

- 相关类库

	ThoughtWorks.QRCode 第三方类库

- DEMO功能

	- Encode 生成二维码图片

		- Encoding 编码
		- Correction Level 等级
		- Version 版本
		- Size 大小

	- Decode 解密二维码
	