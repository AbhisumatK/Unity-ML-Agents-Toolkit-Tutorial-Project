# Unity ML-Agents Tutorial Project

This project is based on the **Code Monkey ML-Agents Tutorial**. It demonstrates the implementation of a basic "Move to Ball" simulation using the Unity Machine Learning Agents Toolkit.

## 🛠️ Tech Stack Used
-   **Unity Engine**: The primary development environment.
-   **ML-Agents Toolkit (Release 21)**: The framework for training intelligent agents.
-   **Python 3.10**: Used for running the training environment.
-   **PyTorch**: The backend machine learning library used by ML-Agents.

## 🧠 Key Learnings
During this tutorial, I explored the following concepts:
-   **Observations**: How the agent scales its world (e.g., position of itself and the ball).
-   **Actions**: The decisions the agent makes (e.g., moving in X and Z directions).
-   **Rewards**: Providing positive reinforcement (`+1.0`) when reaching the target and negative reinforcement (`-1.0`) for falling off or timing out.
-   **Heuristic Mode**: Implementing manual control to debug the environment logic before training.
-   **Training**: Converting Unity scenes into learning environments.

## ⚙️ Configuration Setup
The training process uses a `yaml` configuration file (located in `config/move_to_ball.yaml`). 

### Core Parameters:
-   **Trainer Type**: `ppo` (Proximal Policy Optimization).
-   **Batch Size**: `10`
-   **Buffer Size**: `100`
-   **Learning Rate**: `3.0e-4`
-   **Max Steps**: `500,000` (The total steps the agent will take to learn).

## 🚀 Commands Used

### 1. Start Training
To start a new training session:
```bash
mlagents-learn config/move_to_ball.yaml --run-id=MoveToBall_01
```

### 2. Resume Training
To pick up where you left off in a specific run:
```bash
mlagents-learn config/move_to_ball.yaml --run-id=MoveToBall_01 --resume
```

### 3. Initialize from Previous Run (Transfer Learning)
To start a new run using a pre-trained model as a starting point:
```bash
mlagents-learn config/move_to_ball.yaml --run-id=MoveToBall_New --initialize-from=MoveToBall_01
```
*Note: This is useful for building upon existing knowledge when the environment or task changes slightly.*

### 4. Monitor with TensorBoard
To visualize the training progress, rewards, and policy loss:
```bash
tensorboard --logdir results
```
Open `http://localhost:6006` in your browser.

## 📂 Project Structure
-   `Assets/`: Unity project files, scripts, and materials.
-   `config/`: YAML configuration files for different training scenarios.
-   `results/`: Training logs and generated `.onnx` model files.
-   `venv/`: Python virtual environment for ML-Agents.
