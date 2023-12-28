<p align="center" width="100%">
    <img width="50%" src="Assets/Amuse-Logo-512.png">
</p> 

![GitHub last commit (by committer)](https://img.shields.io/github/last-commit/Stackyard-AI/Amuse)
[![Discord](https://img.shields.io/discord/1189738352715513967?label=Discord&)](https://discord.gg/hThP5VRuHA)
[![YouTube Channel Views](https://img.shields.io/youtube/channel/views/UCIBJC3QFZm0ocvove8oqmSg)](https://www.youtube.com/@StackyardAI)
### **[Discord](https://discord.gg/hThP5VRuHA)**  | **[Youtube](https://www.youtube.com/@StackyardAI)**
__________________________

# Welcome to Amuse!

Amuse is a professional and intuitive Windows UI for harnessing the capabilities of the ONNX (Open Neural Network Exchange) platform, allowing you to easily augment and enhance your creativity with the power of AI.

Amuse, written entirely in .NET, operates locally with a dependency-free architecture, providing a secure and private environment and eliminating the need for intricate setups or external dependencies such as Python. Unlike solutions reliant on external APIs, Amuse functions independently, ensuring privacy by operating offline. External connections are limited to the essential process of downloading models, preserving the security of your data and shielding your creative endeavors from external influences.

### Experience the power of AI without compromise
__________________________

## Features
- **Paint To Image:** Experience real-time AI-generated drawing-based art with stable diffusion.

- **Text To Image:** Generate stunning images from text descriptions with AI-powered creativity.
  
- **Image To Image:** Transform images seamlessly using advanced machine learning models.
  
- **Image Inpaint:** Effortlessly fill in missing or damaged parts of images with intelligent inpainting.

- **Model Management:** Install, download and manage all your models in a simple user interafce.

Amuse provides compatibility with a diverse set of models, including 
- StableDiffusion 1.5
- StableDiffusion Inpaint
- SDXL
- SDXL Inpaint
- SDXL-Turbo
- LatentConsistency
- LatentConsistency XL
- Instaflow

__________________________

## Why Choose Amuse?

Amuse isn't just a tool; it's a gateway to a new realm of AI-enhanced creativity. Unlike traditional machine learning frameworks, Amuse is tailored for artistic expression and visual transformation. This Windows UI brings the power of AI to your fingertips, offering a unique experience in crafting AI-generated art.

### Key Highlights

- **Intuitive AI-Enhanced Editing:** Seamlessly edit and enhance images using advanced machine learning models.
  
- **Creative Freedom:** Unleash your imagination with Text To Image, Image To Image, Image Inpaint, and Live Paint Stable Diffusion features, allowing you to explore novel ways of artistic expression.
  
- **Real-Time Results:** Witness the magic unfold in real-time as Amuse applies live inference, providing instant feedback and empowering you to make creative decisions on the fly.

Amuse is not about building or deploying; it's about bringing AI directly into your creative process. Elevate your artistic endeavors with Amuse, the AI-augmented companion for visual storytellers and digital artists.
__________________________

## Paint To Image
Paint To Image is a cutting-edge image processing technique designed to revolutionize the creative process. This method allows users to paint on a canvas, transforming their artistic expressions into high-quality images while preserving the unique style and details of the original artwork. Harnessing the power of stable diffusion, Paint To Image opens up a realm of possibilities for artistic endeavors, enabling users to seamlessly translate their creative brushstrokes into visually stunning images. Whether it's digital art creation, stylized rendering, or other image manipulation tasks, Paint To Image delivers a versatile and intuitive solution for transforming painted canvases into captivating digital masterpieces.

https://github-production-user-asset-6210df.s3.amazonaws.com/90013272/292652901-f5faabdf-78c7-4d26-baeb-04ed3a542d9f.mp4

## Text To Image
Text To Image Stable Diffusion is a powerful machine learning technique that allows you to generate high-quality images from textual descriptions. It combines the capabilities of text understanding and image synthesis to convert natural language descriptions into visually coherent and meaningful images

https://github-production-user-asset-6210df.s3.amazonaws.com/90013272/292651258-dce31659-8863-4f19-a69c-055570a8ead1.mp4

## Image To Image
Image To Image Stable Diffusion is an advanced image processing and generation method that excels in transforming one image into another while preserving the visual quality and structure of the original content. Using stable diffusion, this technique can perform a wide range of image-to-image tasks, such as style transfer, super-resolution, colorization, and more

https://github-production-user-asset-6210df.s3.amazonaws.com/90013272/292651888-91fd55fd-62a4-45dc-8469-ec44b8cea22f.mp4

## Image Inpaint
Image inpainting is an image modification/restoration technique that intelligently fills in missing or damaged portions of an image while maintaining visual consistency. It's used for tasks like photo restoration and object removal, creating seamless and convincing results.

https://github-production-user-asset-6210df.s3.amazonaws.com/90013272/292652258-c6ffbb17-98d2-483a-9eab-04e4dfad1102.mp4

## Model Manager
![image](https://github.com/Stackyard-AI/Amuse/assets/90013272/0539f55d-96fd-4a12-95f4-9d16ac335859)

Discover the simplicity of our Model Manager – your all-in-one tool for stress-free model management. Easily navigate through an intuitive interface that takes the hassle out of deploying, updating, and monitoring your stable diffusion models. No need for configuration headaches; our Model Manager makes it a breeze to install new models. Stay in control effortlessly, and let your creative process evolve smoothly.

## Getting Started
Get started now with our helpful documentation: https://github.com/Stackyard-AI/Amuse/blob/master/Docs/GettingStarted.md

__________________________


# Hardware Requirements

### Compute Requirements
Generating results demands significant computational time. Below are the minimum requirements for accomplishing such tasks using Amuse
Device | Requirement | 
--- | --- | 
CPU | Any modern Intel/AMD
AMD GPU | Radeon HD 7000 series and above
Intel | HD Integrated Graphics and above (4th-gen core) 
NVIDIA | GTX 600 series and above.


### Memory Requirements
AI operations can be memory-intensive. Below is a small table outlining the minimum RAM or VRAM requirements for Amuse
Model| Device | Precision | RAM/VRAM |
--- | --- | --- | --- |
Stable Diffusion | GPU| 16| ~4GB
Stable Diffusion | CPU/GPU| 32| ~8GB
SDXL | CPU/GPU| 32| ~18GB

### System Requirements
Amuse provides various builds tailored for specific hardware. DirectML is the default choice, offering the broadest compatibility across devices.
Build| Device | Requirements | 
--- | --- | --- |
CPU| CPU| None| 
DirectML| CPU, AMD GPU, Nvidia GPU| At least Windows10| 
CUDA| Nvidia GPU| `CUDA 11`  and `cuDNN` toolkit| 
TensorRT| Nvidia GPU| `CUDA 11` , `cuDNN` and TensorRT libraries| 


### Realtime Requirements
Real-time stable diffusion introduces a novel concept and demands a substantial amount of resources. The table below showcases achievable speeds on commonly tested graphics cards
Device| Model |  FPS |
--- | --- | --- | 
GTX 2080 | [LCM_Dreamshaper_v7_Olive_Onnx](https://huggingface.co/softwareweaver/LCM_Dreamshaper_v7_Olive_Onnx) | 1-2
RTX 3090 | [LCM_Dreamshaper_v7_Olive_Onnx](https://huggingface.co/softwareweaver/LCM_Dreamshaper_v7_Olive_Onnx) | 3-4

__________________________


## Contribution
We welcome contributions to Amuse! If you have any ideas, bug reports, or improvements, feel free to open an issue or submit a pull request.

__________________________

## Reference
OnnxRuntime - [OnnxRuntime](https://onnxruntime.ai/)

OnnxRuntime Services for .NET - [OnnxStack](https://github.com/saddam213/OnnxStack)
