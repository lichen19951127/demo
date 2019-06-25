####系统工程简介：
- 系统采用的ENode框架结构图如下：
![系统结构图](http://git.oschina.net/uploads/images/2015/0721/091308_ebe27b54_362401.png "在这里输入图片标题")

- 程序运行效果图如下：
![输入图片说明](http://git.oschina.net/uploads/images/2015/0722/092143_5a25f5c9_362401.jpeg "在这里输入图片标题")
![输入图片说明](http://git.oschina.net/uploads/images/2015/0722/092159_24a70ed6_362401.jpeg "在这里输入图片标题")
![输入图片说明](http://git.oschina.net/uploads/images/2015/0722/092213_ab6df88b_362401.jpeg "在这里输入图片标题")
![输入图片说明](http://git.oschina.net/uploads/images/2015/0722/092232_793127b9_362401.jpeg "在这里输入图片标题")

####系统工程结构：

######Server
1. BestQA.MessageQueue: 系统消息队列中心
2. BestQA.CommandSubscribe: 为系统命令的订阅处理程序
3. BestQA.EventSubscribe: 为领域事件订阅处理程序

######Other
1. BestQA.Commands: 包含所有的命令（即CQRS框架中的Command）及命令处理CommandHandler
2. BestQA.Domain: 核心领域层（内部包括领域事件的定义）
3. BestQA.EventHandler: 领域事件处理
4. BestQA.Metedata: 通用数据结构定义
5. BestQA.QueryService: 系统查询接口，即CQRS中的Query
6. BestQA.RegisterExtension: 系统中所有命令编码的定义
7. BestQA.Repository: 系统数据存储处理，采用EF方式
8. BestQA.UnitTest: 系统单元测试
9. BestQA.Web: 基于MVC的用户操作界面，前端采用angularjs
10. Lee.Infrastructure: 公共类库，与平台无关

####启动顺序：

- 创建数据库：BestQA，并使用InitTables.sql进行初始化；

######依次运行：
1. BestQA.MessageQueue.exe
2. BestQA.CommandSubscribe.exe
3. BestQA.EventSubscribe.exe
4. BestQA.Web(注意修改连接字符串)

######单元测试：
1. 只运行行BestQA.UnitTest即可，无需任何其它程序

####典型的业务处理流程：

发布一个新问题：

- 用户通过WEB发送CreateNewQuestionCmd
- BestQA.MessageQueue收到命令
- BestQA.CommandSubscribe收到通知，调用BestQA.Commands中的CommandHandler处理，最终通过调用BestQA.Domain处理，然后发送QuestionCreatedEvent
- BestQA.MessageQueue收到领域事件
- BestQA.EventSubscribe收到事件通知，调用BestQA.EventHandler中的EventHandler处理，并通过BestQA.Repository把结果写入数据库
