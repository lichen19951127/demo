var url = "http://123.56.219.247:8061/api/usersapi/getlist";
var page = 0;
var page_size = 20;
var sort = "last";
var is_easy = 0;
var lange_id = 0;
var pos_id = 0;
var unlearn = 0;


// 获取数据的方法，具体怎么获取列表数据大家自行发挥
var GetList = function (that) {
  that.setData({
    hidden: false
  });
  wx.request({
    url: url,
    data: {
      // page: page,
      // page_size: page_size,
      // sort: sort,
      // is_easy: is_easy,
      // lange_id: lange_id,
      // pos_id: pos_id,
      // unlearn: unlearn
    },
    success: function (res) {
      //console.info(that.data.list);
      var list = that.data.list;
      for (var i = 0; i < res.data.length; i++) {
        list.push(res.data[i]);
      }
      that.setData({
        list: list
      });
      page++;
      that.setData({
        hidden: true
      });
    }
  });
}
Page({
  data: {
    hidden: true,
    list: [],
    scrollTop: 0,
    scrollHeight: 0
  },
  onLoad: function () {
    //  这里要非常注意，微信的scroll-view必须要设置高度才能监听滚动事件，所以，需要在页面的onLoad事件中给scroll-view的高度赋值
    var that = this;
    wx.getSystemInfo({
      success: function (res) {
        console.info(res.windowHeight);
        that.setData({
          scrollHeight: res.windowHeight
        });
      }
    });
  },
  onShow: function () {
    //  在页面展示之后先获取一次数据
    var that = this;
    GetList(that);
  },
  bindDownLoad: function () {
    //  该方法绑定了页面滑动到底部的事件
    var that = this;
    GetList(that);
  },
  scroll: function (event) {
    //  该方法绑定了页面滚动时的事件，我这里记录了当前的position.y的值,为了请求数据之后把页面定位到这里来。
    this.setData({
      scrollTop: event.detail.scrollTop
    });
  },
  refresh: function (event) {
    //  该方法绑定了页面滑动到顶部的事件，然后做上拉刷新
    page = 0;
    this.setData({
      list: [],
      scrollTop: 0
    });
    GetList(this)
  },
  add:function(e){
    wx.navigateTo({
      url: '../add/add'
    })
  },
  update:function(e){
    wx.navigateTo({
      url: '../update/update?id='+e.currentTarget.id
    })

  },
  delete: function (e) {
    wx.request({
      url: 'http://123.56.219.247:8061/api/usersapi/delete?Id='+e.currentTarget.id, //这里填写你的接口路径,注意一定要在微信小程序中授权过得https数字加密域名
      method: 'post',//请求方式
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
          wx.showToast({ title: '删除成功' })
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
})
