# 🎮🤖 Synth-Companion — Immersive Turing Test in a VR Escape Room

> *Can you tell if your teammate is human... or AI?*

[![Unity](https://img.shields.io/badge/Unity-2022.3-black?logo=unity)](https://unity.com)
[![Python](https://img.shields.io/badge/Python-3.10+-blue?logo=python)](https://python.org)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)

---

## 🧠 Concept

Synth-Companion is a **hybrid VR/Desktop escape room** where a team of players must solve puzzles while collaborating with what they believe is another human — but is actually an advanced AI agent.

The system studies **Theory of Mind** in Human-Machine interactions: how do humans build trust, detect deception, and collaborate with artificial agents in high-pressure cooperative environments?

---

## 🏗️ Architecture

```
┌────────────┐     Netcode      ┌──────────────────────┐     Netcode     ┌──────────────────┐
│  VR Player │ ←─────────────→ │   Unity Game Engine  │ ←─────────────→ │  Desktop Player  │
│ (XR/Oculus)│                 │  C# · ShaderLab · XR │                 │   (Chat/PC UI)   │
└────────────┘                 └──────────┬───────────┘                 └──────────────────┘
                                          │
                               ┌──────────▼───────────┐
                               │   Synth — AI Agent   │
                               │ Behavior · Mimicry   │
                               │  Theory of Mind sim  │
                               └──────────┬───────────┘
                                          │
                    ┌─────────────────────▼──────────────────────┐
                    │              Python Backend                  │
                    │  ┌──────────┐  ┌──────────┐  ┌──────────┐  │
                    │  │ RL Engine│  │LLM Module│  │Analytics │  │
                    │  │PPO/DQN   │  │ Prompting│  │Behav.logs│  │
                    │  │Big Data  │  │ Emotions │  │ToM Study │  │
                    │  └──────────┘  └──────────┘  └──────────┘  │
                    └─────────────────────────────────────────────┘
```

---

## 🔧 Tech Stack

| Layer | Technology |
|-------|-----------|
| Game Engine | Unity 2022.3 (C#, ShaderLab, HLSL) |
| VR/XR | Unity XR Toolkit, OpenXR |
| Multiplayer | Netcode for GameObjects, ParrelSync |
| On-device AI | Unity Sentis (TTS / STT) |
| AI Training | Python — PPO/DQN Reinforcement Learning |
| Language | LLM API (GPT-4 / local model) |
| Analytics | Behavioral log pipeline |

---

## 🎯 Key Features

- 🤖 **AI Behavioral Mimicry** — RL-trained agent that solves puzzles AND imitates human hesitation, errors, and social cues
- 🗣️ **Real-time Voice** — Unity Sentis TTS/STT with < 200ms latency for VR player interaction
- 💬 **LLM Communication** — Advanced prompt engineering for natural, context-aware dialogue with Desktop players
- 🌐 **Cross-platform Multiplayer** — Synchronized state between VR and Desktop clients
- 📊 **Behavioral Analytics** — Every interaction logged and analyzed for Theory of Mind research

---

## 🚀 Getting Started

```bash
git clone https://github.com/ZOUHAIR-SERRAR/synth-companion.git
cd synth-companion
# Open with Unity 2022.3+
# Install Python dependencies:
pip install -r backend/requirements.txt
# Launch backend:
python backend/main.py
```

---

## 👤 Author

**Zouhair SERRAR** — Étudiant Ingénieur SI & Big Data, ENSA Berrechid
🔗 [LinkedIn](https://linkedin.com/in/zouhair-serrar) | 📧 serrar.ensa@uhp.ac.ma

---

*Built as an academic research project exploring Human-AI collaboration and Theory of Mind.*
