#ui自适应
画布的scaler调整整体画布的大小。选择screen match mode为expand

ui整体加一个空gameobject作为wrapper

设置left top right bottom 为0
anchors minx=0 maxx=1 miny=0 maxy=1

这样wrapper会铺满屏幕

添加lef为靠左节点

设置minx maxx=0，miny maxy=1

左上对齐

所有子图形设置 minx maxx miny maxy 0.5

调整posx和posy即为图形位置

添加空节点bot下对齐

minx maxx=0.5 miny maxy 0

只有添加了按钮组件的才能点击

```cshape
var ui = GameObject.Find("Canvas").transform.Find("wrapper");
		var btn = ui.transform.Find("left").Find("btn1").gameObject.GetComponent<Button>();
		Debug.Log(btn);
		btn.onClick.AddListener(
		   delegate ()
		   {
			   Debug.Log("click");
		   }
		  );
```

需要把ui打包成一张纹理
添加sprite atlas然后把图片纹理添加上去

