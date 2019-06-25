// pages/user/add/add.js

var GetData =function(that){
  console.log(that);
  wx.request({
    url: 'http://123.56.219.247:8061/api/usersapi/GetSingle?Id=' + that.data.id, //这里填写你的接口路径,注意一定要在微信小程序中授权过得https数字加密域名
    method: 'get',//请求方式
    header: { //接口口返回的数据是什么类型，这里就体现了微信小程序的强大，直接给你解析数据，再也不用去寻找各种方法去解析json，xml等数据了
      'Content-Type': 'application/json'
    },
    data: {//请求数据

    },
    success: function (res) {
      if (res.statusCode == 200) {//statusCode==200表示请求成功，有数据返回
        //这里就是请求成功后，进行一些函数操作
        console.log(res.data)//// 服务器回包内容
        console.warn(res)
        var radioItems = that.data.radioItems;
        for (var i = 0, len = radioItems.length; i < len; ++i) {
          radioItems[i].checked = radioItems[i].value == res.data.sex;
        }
        that.setData({
          id: res.data.id,
          Name: res.data.name,
          Sex: res.data.sex,
          Age: res.data.age,
          radioItems: radioItems
        })
      }
    },
    fail: function (res) {
      wx.showToast({ title: '系统错误' })
    },
    complete: () => {
      wx.hideLoading();
    } //complete接口执行后的回调函数，无论成功失败都会调用
  });

}
Page({

  /**
   * 页面的初始数据
   */
  data: {
    id:0,
    radioItems: [
      { name: '女', value: '0', checked: true },
      { name: '男', value: '1' }
    ],
    Name: '',
    Age: 0,
    isAgree: true,
    Sex: 0
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.setData({
      id: options.id
    })
    console.log(this.data.id)
    var that = this;
    GetData(that);

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },
  radioChange: function (e) {
    console.log('radio发生change事件，携带value值为：', e.detail.value);

    var radioItems = this.data.radioItems;
    for (var i = 0, len = radioItems.length; i < len; ++i) {
      radioItems[i].checked = radioItems[i].value == e.detail.value;
    }

    this.setData({
      radioItems: radioItems,
      Sex: e.detail.value
    });
  },
  bindAgreeChange: function (e) {
    this.setData({
      isAgree: !!e.detail.value.length
    });
  },
  bindNameChange: function (e) {
    console.log(e);
    var that = this;
    this.setData({
      Name: e.detail.value
    })
  },
  bindAgeChange: function (e) {
    console.log(e);
    var that = this;
    this.setData({
      Age: e.detail.value
    })
  },
  showTopTips: function () {
    var that = this;
    console.log(that);
    // this.setData({
    //   //showTopTips: true,
    //   Name:that.data.Name,
    //   Age:that.data.Age,
    //   Sex:that.data.radioItems.checked=true.value
    // });
    setTimeout(function () {
      that.setData({
        showTopTips: false
      });
    }, 3000);
    if (that.data.isAgree) {
      wx.request({
        url: 'http://123.56.219.247:8061/api/usersapi/update', //这里填写你的接口路径,注意一定要在微信小程序中授权过得https数字加密域名
        method: 'post',//请求方式
        header: { //接口口返回的数据是什么类型，这里就体现了微信小程序的强大，直接给你解析数据，再也不用去寻找各种方法去解析json，xml等数据了
          'Content-Type': 'application/json'
        },
        data: {//请求数据
          Id:that.data.id,
          Name: that.data.Name,
          Sex: that.data.Sex,
          Age: that.data.Age
        },
        success: function (res) {
          if (res.statusCode == 200) {//statusCode==200表示请求成功，有数据返回
            //这里就是请求成功后，进行一些函数操作
            console.log(res.data)//// 服务器回包内容
            console.warn(res)
            wx.showToast({ title: '编辑成功' })
            setTimeout(function () {
              wx.navigateTo({
                url: '../list/index'
              })
            }, 3000);
          }
        },
        fail: function (res) {
          wx.showToast({ title: '系统错误' })
        },
        complete: () => {
          wx.hideLoading();
        } //complete接口执行后的回调函数，无论成功失败都会调用
      });
    }
  }
})