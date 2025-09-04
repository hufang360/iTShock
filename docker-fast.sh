#!/bin/bash

# TShock Docker 快速部署脚本
# 作者: hufang360
# 版本: 1.0

# 显示帮助信息
show_help() {
	echo "TShock Docker 快速部署脚本"
	echo ""
	echo "用法:"
	echo "  $0 [选项]"
	echo ""
	echo "选项:"
	echo "  -server <名称>        服务器名称 (默认: S1)"
	echo "  -dll <模式>           插件模式: lite|full (默认: lite)"
	echo "  -port <端口>          游戏端口 (默认: 7777)"
	echo "  -portresetapi <端口>  重置API端口 (可选，例如 7878，不指定则不启用)"
	echo "  -motd <消息>          服务器欢迎消息"
	echo "  -worldname <名称>     世界名称"
	echo "  -autocreate <大小>    自动创建世界大小: 1-3 (1=小, 2=中, 3=大) (默认: 3)"
	echo "  -worldevil <类型>     世界邪恶类型: random|corrupt|crimson (默认: random)"
	echo "  -difficulty <难度>    世界难度: 0-3 (0=普通, 1=专家, 2=大师, 3=旅程) (默认: 2)"
	echo "  -maxplayers <数量>    最大玩家数 (默认: 8)"
	echo "  -skipall              跳过所有插件下载"
	echo "  -help                 显示此帮助信息"
	echo ""
	echo "示例:"
	echo "  $0                                           # 使用默认设置"
	echo "  $0 -server S81 -dll full               # 指定服务器名和完整插件"
	echo "  $0 -port 8888 -maxplayers 8 -difficulty 2  # 自定义端口、玩家数和难度"
	echo ""
	echo "插件模式说明:"
	echo "  lite - 精简版插件包 (FastDeploy, AutoRegister, NoVersionLimit)"
	echo "  full - 完整版插件包 (包含hf经常使用的插件)"
	echo ""
	echo "世界设置说明:"
	echo "  autocreate: 1=小世界, 2=中世界, 3=大世界"
	echo "  worldevil: random=随机, corrupt=腐化, crimson=猩红"
	echo "  difficulty: 0=普通, 1=专家, 2=大师, 3=旅程"
}

# 默认参数
server="S1"
dll="lite"
port=7777
port_resetapi=""              # 默认不设置，只有用户明确指定时才启用
port_resetapi_specified=false # 标记是否用户指定了此参数
motd="旅途的终点"
worldname="Terraria"
autocreate=3
worldevil="random"
difficulty=2
maxplayers=8
skipall=false # 是否跳过插件下载

# 解析命令行参数
while [[ $# -gt 0 ]]; do
	case $1 in
	-help | --help | -h)
		show_help
		exit 0
		;;
	-server)
		server="$2"
		shift 2
		;;
	-dll)
		if [[ "$2" != "lite" && "$2" != "full" ]]; then
			echo "错误: dll 参数只能是 'lite' 或 'full'"
			exit 1
		fi
		dll="$2"
		shift 2
		;;
	-port)
		if ! [[ "$2" =~ ^[0-9]+$ ]] || [ "$2" -lt 1 ] || [ "$2" -gt 65535 ]; then
			echo "错误: 端口必须是 1-65535 之间的数字"
			exit 1
		fi
		port="$2"
		shift 2
		;;
	-portresetapi)
		if ! [[ "$2" =~ ^[0-9]+$ ]] || [ "$2" -lt 1 ] || [ "$2" -gt 65535 ]; then
			echo "错误: API端口必须是 1-65535 之间的数字"
			exit 1
		fi
		port_resetapi="$2"
		port_resetapi_specified=true
		shift 2
		;;
	-motd)
		motd="$2"
		shift 2
		;;
	-worldname)
		worldname="$2"
		shift 2
		;;
	-autocreate)
		if ! [[ "$2" =~ ^[1-3]$ ]]; then
			echo "错误: autocreate 参数必须是 1-3 之间的数字 (1=小, 2=中, 3=大)"
			exit 1
		fi
		autocreate="$2"
		shift 2
		;;
	-worldevil)
		if [[ "$2" != "random" && "$2" != "corrupt" && "$2" != "crimson" ]]; then
			echo "错误: worldevil 参数只能是 'random', 'corrupt' 或 'crimson'"
			exit 1
		fi
		worldevil="$2"
		shift 2
		;;
	-difficulty)
		if ! [[ "$2" =~ ^[0-3]$ ]]; then
			echo "错误: difficulty 参数必须是 0-3 之间的数字 (0=普通, 1=专家, 2=大师, 3=旅程)"
			exit 1
		fi
		difficulty="$2"
		shift 2
		;;
	-maxplayers)
		if ! [[ "$2" =~ ^[0-9]+$ ]] || [ "$2" -lt 1 ] || [ "$2" -gt 255 ]; then
			echo "错误: maxplayers 参数必须是 1-255 之间的数字"
			exit 1
		fi
		maxplayers="$2"
		shift 2
		;;
	-skipall)
		skipall=true
		shift 1
		;;
	*)
		echo "错误: 未知参数 '$1'"
		echo "使用 '$0 -help' 查看帮助信息"
		exit 1
		;;
	esac
done

# 显示配置信息
echo "================================"
echo "TShock 服务器配置"
echo "================================"
echo "服务器名称: $server"
if [ "$skipall" = true ]; then
	echo "插件模式: 跳过下载 (使用现有插件)"
else
	echo "插件模式: $dll"
fi
echo "游戏端口: $port"
if [ "$port_resetapi_specified" = true ]; then
	echo "API端口: $port_resetapi (已启用)"
else
	echo "API端口: 未启用 (使用 -portresetapi 参数启用)"
fi
echo "欢迎消息: $motd"
echo "世界名称: $worldname"
echo "世界大小: $autocreate (1=小, 2=中, 3=大)"
echo "邪恶类型: $worldevil"
echo "游戏难度: $difficulty (0=普通, 1=专家, 2=大师, 3=旅程)"
echo "最大玩家: $maxplayers"
echo "================================"

# 切换工作目录
cd "$(dirname "$0")" || exit

# 创建必要的目录
tshock_dir="./$server/tshock"
worlds_dir="./$server/worlds"
plugins_dir="./$server/plugins"
mkdir -p "$tshock_dir"
mkdir -p "$worlds_dir"
mkdir -p "$plugins_dir"

# 下载插件
prefix_url=https://github.com/hufang360/iTShock/raw/refs/heads/master/dlls/202509
dlls_lite=(
	FastDeploy-v1.2.dll
	AutoRegister-v1.3.3.0-ts523.dll
	NoVersionLimit.dll
)

dlls_full=(
	FastDeploy-v1.2.dll
	AutoRegister-v1.3.3.0-ts523.dll
	NoVersionLimit.dll
	PlayerManager-v1.3.4-ts523.dll
	WorldModify-v1.4.0.8-ts523.dll
	AutoTeam-pink.dll
	BetterWhitelist2.2.dll
	ChestTool-v1.1-ts523.dll
	FishShop-v1.4.4-ts523.dll
	ShowMe.dll
)

down_full() {
	echo "正在下载完整版插件..."
	for dll in "${dlls_full[@]}"; do
		echo "下载: $dll"
		curl -L -o "$plugins_dir/$dll" "$prefix_url/$dll"
		if [ $? -eq 0 ]; then
			echo "✓ $dll 下载成功"
		else
			echo "✗ $dll 下载失败"
		fi
	done
}

down_lite() {
	echo "正在下载精简版插件..."
	for dll in "${dlls_lite[@]}"; do
		echo "下载: $dll"
		curl -L -o "$plugins_dir/$dll" "$prefix_url/$dll"
		if [ $? -eq 0 ]; then
			echo "✓ $dll 下载成功"
		else
			echo "✗ $dll 下载失败"
		fi
	done
}

# 根据dll参数选择下载模式
echo ""
if [ "$skipall" = true ]; then
	echo "⏭️  跳过插件下载，使用现有插件文件"
	echo "   插件目录: ./$server/plugins/"
	if [ ! -d "./$server/plugins" ] || [ -z "$(ls -A ./$server/plugins 2>/dev/null)" ]; then
		echo "   ⚠️  警告: 插件目录为空或不存在，服务器将以原版模式运行"
	else
		echo "   ✓ 发现现有插件文件"
	fi
elif [ "$dll" = "full" ]; then
	echo "📦 开始下载完整版插件包..."
	down_full
else
	echo "📦 开始下载精简版插件包..."
	down_lite
fi

# 下载镜像
echo ""
echo "正在拉取 TShock Docker 镜像..."
echo "提示: 如果拉取失败，可以先在本地拉取后传输到服务器"
echo ""
echo "本地拉取方法 (macOS/Linux):"
echo "  docker pull --platform linux/amd64 ghcr.io/pryaxis/tshock:latest"
echo "  docker save -o tshock.tar ghcr.io/pryaxis/tshock:latest"
echo "  tar -czvf tshock.tar.gz tshock.tar"
echo ""
echo "服务器加载方法:"
echo "  tar -xzvf tshock.tar.gz"
echo "  docker load -i tshock.tar"
echo "  rm -f tshock.tar tshock.tar.gz"
echo ""

image=ghcr.io/pryaxis/tshock:latest
if docker pull "$image"; then
	echo "✓ Docker 镜像拉取成功"
else
	echo "✗ Docker 镜像拉取失败，请检查网络连接或使用离线方式"
	exit 1
fi

# 停止并删除已存在的容器
container_name="tshock"
if docker ps -a --format 'table {{.Names}}' | grep -q "^$container_name$"; then
	echo "停止并删除已存在的容器: $container_name"
	docker stop "$container_name" 2>/dev/null
	docker rm "$container_name" 2>/dev/null
fi

# 运行镜像
echo ""
echo "正在启动 TShock 服务器..."

# 构建 Docker 运行命令
docker_cmd="docker run -d --name $container_name -p $port:7777"

# 只有用户指定了 portresetapi 才添加端口映射
if [ "$port_resetapi_specified" = true ]; then
	docker_cmd="$docker_cmd -p $port_resetapi:7878"
fi

# 添加卷映射和其他参数
docker_cmd="$docker_cmd -v "$tshock_dir":/tshock -v "$worlds_dir":/worlds -v "$plugins_dir":/plugins $image"
docker_cmd="$docker_cmd -world /worlds/world.wld -motd \"$motd\" -lang 7 -autocreate $autocreate -worldevil $worldevil -difficulty $difficulty -maxplayers $maxplayers"

# 执行命令
eval $docker_cmd

if [ $? -eq 0 ]; then
	echo ""
	echo "🎉 TShock 服务器启动成功！"
	echo "================================"
	echo "服务器信息:"
	echo "  容器名称: $container_name"
	echo "  游戏端口: $port"
	if [ "$port_resetapi_specified" = true ]; then
		echo "  API端口: $port_resetapi"
	else
		echo "  API端口: 未启用"
	fi
	echo "  服务器地址: 你服务器 ip:$port (本地)"
	echo "  配置文件: $tshock_dir"
	echo "  世界文件: $worlds_dir/world.wld"
	echo "  插件目录: $plugins_dir"
	echo "================================"

	# 等待几秒让服务器启动
	echo ""
	echo "⏳ 服务器初始化中..."
	echo ""
	echo "📋 首次启动操作指南："
	echo "================================"
	echo "1️⃣ 查看地图创建进度"
	echo "   首次启动需要创建地图，大约需要几分钟时间"
	echo "   地图位置: $worlds_dir/world.wld"
	echo "   查看进度: docker logs -f $container_name"
	echo ""
	echo "2️⃣ 进入服务器控制台"
	echo "   等待地图创建完成后执行:"
	echo "   docker attach --sig-proxy=false $container_name"
	echo ""
	echo "3️⃣ 开启强制开荒模式"
	echo "   在控制台中输入: /fd init"
	echo "   然后按 Enter 键确认"
	echo ""
	echo "4️⃣ 退出控制台"
	echo "   使用 Ctrl+C 退出控制台（不会关闭服务器）"
	echo ""
	echo "5️⃣ 重启服务器完成配置"
	echo "   docker restart $container_name"
	echo "   重启完成后即可开始联机游戏！"
	echo "================================"
	sleep 3

	# 检查容器状态
	if docker ps --format 'table {{.Names}}\t{{.Status}}' | grep -q "$container_name.*Up"; then
		echo "✓ 服务器运行状态正常"
	else
		echo "⚠️  服务器可能启动异常，请检查日志"
	fi
else
	echo ""
	echo "❌ TShock 服务器启动失败！"
	echo "请检查:"
	echo "  1. Docker 是否正常运行"
	if [ "$port_resetapi_specified" = true ]; then
		echo "  2. 端口 $port 和 $port_resetapi 是否被占用"
	else
		echo "  2. 端口 $port 是否被占用"
	fi
	echo "  3. 磁盘空间是否充足"
	exit 1
fi

# 使用说明
echo ""
echo "📋 服务器管理命令"
echo "================================"
echo "进入服务器控制台:"
echo "  docker attach $container_name"
echo ""
echo "进入控制台 (推荐方式，Mac/Linux):"
echo "  docker attach --sig-proxy=false $container_name"
echo "  💡 使用 Ctrl+C 退出控制台而不关闭服务器"
echo ""
echo "查看服务器日志:"
echo "  docker logs -f $container_name"
echo ""
echo "服务器管理:"
echo "  docker stop $container_name      # 停止服务器"
echo "  docker start $container_name     # 启动服务器"
echo "  docker restart $container_name   # 重启服务器"
echo "  docker rm $container_name        # 删除容器"
echo ""
echo "文件位置:"
echo "  配置文件: $tshock_dir"
echo "  世界文件: $worlds_dir"
echo "  插件文件: $plugins_dir"
echo ""
echo "🎮 现在可以使用 Terraria 客户端连接到服务器了！"
echo "   服务器地址: localhost:$port (如果是本地)"
echo "================================"
