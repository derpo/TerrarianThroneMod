require 'fileutils'

def copy_files
  return unless Gem::Platform.local.os == 'darwin'
  copy_assembly
  copy_assets
end

def target_dir_root
  File.expand_path('~/Library/Application Support/Terraria/ModLoader/Mod Sources/TerrarianThroneMod').tap do |path|
    FileUtils.makedirs(path, verbose: true) unless File.exist?(path)
  end
end

def copy_assembly
  asm_filename = File.join(__dir__, 'bin', 'Debug', 'TerrarianThroneMod.dll')

  # tMod only cares that the Windows.dll exists. This is just to get things working for development on Mac.
  %w(Mono.dll Windows.dll).each do |target_file|
    FileUtils.copy asm_filename, File.join(target_dir_root, target_file), verbose: true
  end
end

def copy_asset(asset_file)
  target_dir = File.join(target_dir_root, File.dirname(asset_file).sub(__dir__, ''))
  FileUtils.makedirs(target_dir, verbose: true) unless File.exist?(target_dir)
  target_file = File.join(target_dir, File.basename(asset_file))
  return if File.exist?(target_file)
  FileUtils.copy asset_file, target_file, verbose: true
end

def copy_assets
  (Dir[File.join(__dir__, '{build,description}.txt')] +
    Dir[File.join(__dir__, '**', '*.{png,wav}')]).each { |asset_file| copy_asset(asset_file) }
end

copy_files
