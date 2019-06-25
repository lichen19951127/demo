var fpraw1 = "";
var fpraw2 = "";
function toJson(str) 
{
    //var obj = JSON.parse(str);
    //return obj;
    // return eval('(' + str + ')');
}
function clearForm() 
{
    document.getElementById("handjpg").src = "";
}
function connect() 
{
    clearForm();

    var SynCardOcx1 = document.getElementById("SynCardOcx1");

    var result = SynCardOcx1.openIDReader();
    document.getElementById("result").value = result;
}
function disconnect() 
{
    clearForm();

    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.closeIDReader();
    document.getElementById("result").value = result;
}
function readIMEI() 
{
    clearForm();

    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.readIDCardIMEI();
    document.getElementById("result").value = result;
}

function findCert() {
    clearForm();

    var SynCardOcx1 = document.getElementById("SynCardOcx1");

    var result = SynCardOcx1.authFindIDReader();
    document.getElementById("result").value = result;
}

function readCert() 
{
    clearForm();

    var SynCardOcx1 = document.getElementById("SynCardOcx1");

    var result = SynCardOcx1.readIDCardContentEx();
    document.getElementById("result").value = result;
}

function readPhoto() {
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.getJpgPhotoBaseBuf();
    var resultObj = toJson(result);
    document.getElementById("result").value = result;
  
    document.getElementById("handjpg").src = 'data:image/jpeg;base64,' +  resultObj.content; 
}

function initFP()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.initFP();
    document.getElementById("result").value = result;
}

function CloseFP()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.closeFP();
    document.getElementById("result").value = result;
}

function fpGetData()
{
    clearForm();
    fpraw2 = fpraw1;
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.fpGetData(11);
    document.getElementById("result").value = result;
    var dataObj = eval("("+result+")");
    fpraw1 = dataObj.content.FPBase64;
    document.getElementById("ZPImg").src = 'data:image/jpeg;base64,' +  dataObj.content.BmpBase64; 
    
}

function SendFPSound()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.SendFPSound(11);
    document.getElementById("result").value = result;  
}

function FPMatch()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.FPMatch(fpraw1,fpraw2);
    document.getElementById("result").value = result;
}

function openCamera()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.openCamera();
    document.getElementById("result").value = result;
}

function closeCamera()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.closeCamera();
    document.getElementById("result").value = result;
}
function getCameraImage()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.getCameraImage();
    document.getElementById("result").value = result;
    var dataObj = eval("("+result+")");
    document.getElementById("ZPImg").src = 'data:image/jpeg;base64,' +  dataObj.content.CameraBase64; 
}

function StartCameraVideo()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.StartCameraVideo();
    document.getElementById("result").value = result;
}

function StopCameraVideo()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.StopCameraVideo();
    document.getElementById("result").value = result;
}

function getHistoryData()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.getHistoryData(0,"","","");
    document.getElementById("result").value = result;
}

function delHistoryData()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.delHistoryData(1,"30821198301090030","","");
    document.getElementById("result").value = result;
}


function getSingleAllData()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.getSingleAllData();
    document.getElementById("result").value = result;
}

function setFpAndPhotoPath()
{
    clearForm();
    var SynCardOcx1 = document.getElementById("SynCardOcx1");
    var result = SynCardOcx1.setFpAndPhotoPath("D:\\����\\FP\\","D:\\����\\PH\\");
    document.getElementById("result").value = result;
}

function Download(){
        //cavas ����ͼƬ������  js ʵ��
        //------------------------------------------------------------------------
        //1.ȷ��ͼƬ������  ��ȡ����ͼƬ��ʽ data:image/Png;base64,...... 
        var type ='bmp';//����ҪʲôͼƬ��ʽ ��ѡʲô��
        var d=document.getElementById("canvas");
        var imgdata=d.toDataURL(type);
        //2.0 ��mime-type��Ϊimage/octet-stream,ǿ�������������
        var fixtype=function(type){
            type=type.toLocaleLowerCase().replace(/jpg/i,'jpeg');
            var r=type.match(/png|jpeg|bmp|gif/)[0];
            return 'image/'+r;
        };
        imgdata=imgdata.replace(fixtype(type),'image/octet-stream');
        //3.0 ��ͼƬ���浽����
        var savaFile=function(data,filename)
        {
            var save_link=document.createElementNS('http://www.w3.org/1999/xhtml', 'a');
            save_link.href=data;
            save_link.download=filename;
            var event=document.createEvent('MouseEvents');
            event.initMouseEvent('click',true,false,window,0,0,0,0,0,false,false,false,false,0,null);
            save_link.dispatchEvent(event);
        };
        var filename=''+new Date().getSeconds()+'.'+type;  
        //ע�⿩ ����ͼƬ���صıȽ��� ��ֱ���õ�ǰ��������ͼƬ����
        savaFile(imgdata,filename);
        
        };

