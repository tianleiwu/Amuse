# ModelTemplate

## StableDiffuion Model


## Schema
```json
{
	"Name": string,
	"ImageIcon": string(url),
	"Author": string,
	"Website": string(url),
	"Description": string,
	"Tags": [ string ],
	"IsUserTemplate": bool,
	"Template": string,
	"Category": enum,
	"StableDiffusionTemplate": {
	  "PipelineType": enum,
	  "ModelType": enum,
	  "SampleSize": integer,
	  "DiffuserTypes": [ enum ],
	  "SchedulerDefaults": {
		"Steps": int,
		"StepsMin": int,
		"StepsMax": int,
		"Guidance": float,
		"GuidanceMin": float,
		"GuidanceMax": float,
		"SchedulerType": enum
	  }
	},
	"Repository": string(url),
	"RepositoryBranch": string(url),
	"RepositoryFiles": [ string(url) ],
	"PreviewImages": [ string(url) ]
}
```
**Enum Reference:**
[[DiffuserType]](https://github.com/saddam213/OnnxStack/blob/master/OnnxStack.StableDiffusion/Enums/DiffuserType.cs) 
[[ModelType]](https://github.com/saddam213/OnnxStack/blob/master/OnnxStack.StableDiffusion/Enums/ModelType.cs) 
[[PipelineType]](https://github.com/saddam213/OnnxStack/blob/master/OnnxStack.StableDiffusion/Enums/DiffuserPipelineType.cs) 
[[SchedulerType]](https://github.com/saddam213/OnnxStack/blob/master/OnnxStack.StableDiffusion/Enums/SchedulerType.cs) 

## Example

```json
{
	"Name": "LCM Dreamshaper v7",
	"ImageIcon": "https://raw.githubusercontent.com/luosiallen/latent-consistency-model/main/lcm_logo.png",
	"Author": "SimianLuo",
	"Website": "https://latent-consistency-models.github.io/",
	"Description": "Latent Consistency Model (LCM) was proposed in Latent Consistency Models: Synthesizing High-Resolution Images....",
	"Tags": [ "CPU", "GPU", "F32" ],
	"IsUserTemplate": true,
	"Template": "LCM",
	"Category": "StableDiffusion",
	"StableDiffusionTemplate": {
	  "PipelineType": "LatentConsistency",
	  "ModelType": "Base",
	  "SampleSize": 512,
	  "DiffuserTypes": [
		"TextToImage",
		"ImageToImage",
		"ImageInpaintLegacy"
	  ],
	  "SchedulerDefaults": {
		"Steps": 4,
		"StepsMin": 1,
		"StepsMax": 50,
		"Guidance": 1,
		"GuidanceMin": 0,
		"GuidanceMax": 2,
		"SchedulerType": "LCM"
	  }
	},
	"Repository": "https://huggingface.co/SimianLuo/LCM_Dreamshaper_v7",
	"RepositoryFiles": [
	  "https://huggingface.co/SimianLuo/LCM_Dreamshaper_v7/resolve/onnx/unet/model.onnx",
	  "https://huggingface.co/SimianLuo/LCM_Dreamshaper_v7/resolve/onnx/unet/model.onnx_data",
	  "https://huggingface.co/SimianLuo/LCM_Dreamshaper_v7/resolve/onnx/text_encoder/model.onnx",
	  "https://huggingface.co/SimianLuo/LCM_Dreamshaper_v7/resolve/onnx/vae_decoder/model.onnx",
	  "https://huggingface.co/SimianLuo/LCM_Dreamshaper_v7/resolve/onnx/vae_encoder/model.onnx"
	],
	"PreviewImages": [
	]
}
```



## Upscale Model


## Schema
```json
{
	"Name": string,
	"ImageIcon": string(url),
	"Author": string,
	"Website": string(url),
	"Description": string,
	"Tags": [ string ],
	"IsUserTemplate": bool,
	"Template": string,
	"Category": enum,
	"UpscaleTemplate":{
		"SampleSize": int,
		"ScaleFactor": int,
	},
	"Repository": string(url),
	"RepositoryBranch": string(url),
	"RepositoryFiles": [ string(url) ],
	"PreviewImages": [ string(url) ]
}
```


## Example

```json
 {
   "Name": "Swin2SR x4",
   "ImageIcon": "",
   "Author": "Xenova",
   "Description": "Swin2SR is like a magic wand for pictures and videos. It makes compressed images...",
   "Website": "https://arxiv.org/abs/2209.11345",
   "Tags": [ "CPU", "GPU", "F32" ],
   "IsUserTemplate": true,
   "Category": "Upscaler",
   "Template": "Upscaler",
   "UpscaleTemplate": {
     "Channels": 3,
     "ScaleFactor": 4,
     "SampleSize": 512
   },
   "Repository": "https://huggingface.co/Xenova/swin2SR-classical-sr-x4-64",
   "RepositoryFiles": [
     "https://huggingface.co/Xenova/swin2SR-classical-sr-x4-64/resolve/main/onnx/model.onnx"
   ]
 }
```